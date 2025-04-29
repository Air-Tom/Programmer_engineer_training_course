using System;
using System.Linq;
using Microsoft.ML;
using Microsoft.ML.Data;
using Microsoft.ML.Trainers;
using Microsoft.ML.Transforms;

namespace BikeSharingPrediction
{
    class Program
    {
        // Путь к файлам данных
        private static string _dataPath = "C:\\Users\\User\\Documents\\Visual Studio 2022\\bikeSharingApp\\Data\\bike_sharing.csv";

        // Классы для обработки данных
        public class BikeRentalData
        {
            [LoadColumn(0)]
            public float Season { get; set; }

            [LoadColumn(1)]
            public float Month { get; set; }

            [LoadColumn(2)]
            public float Hour { get; set; }

            [LoadColumn(3)]
            public float Holiday { get; set; }

            [LoadColumn(4)]
            public float Weekday { get; set; }

            [LoadColumn(5)]
            public float WorkingDay { get; set; }

            [LoadColumn(6)]
            public float WeatherCondition { get; set; }

            [LoadColumn(7)]
            public float Temperature { get; set; }

            [LoadColumn(8)]
            public float Humidity { get; set; }

            [LoadColumn(9)]
            public float Windspeed { get; set; }

            [LoadColumn(10)]
            [ColumnName("Label")] 
            public bool RentalType { get; set; }
        }

        public class RentalTypePrediction
        {
            [ColumnName("PredictedLabel")]
            public bool PredictedRentalType { get; set; }

            public float Probability { get; set; }

            public float Score { get; set; }
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Предсказание типа аренды велосипеда с использованием ML.NET");

            // 1. Создание ML.NET контекста
            var mlContext = new MLContext(seed: 0);

            // 2. Загрузка данных
            IDataView dataView = mlContext.Data.LoadFromTextFile<BikeRentalData>(
                path: _dataPath,
                hasHeader: true,
                separatorChar: ',');

            // 3. Разделение данных на обучающую и тестовую выборки
            var trainTestSplit = mlContext.Data.TrainTestSplit(dataView, testFraction: 0.2);
            var trainData = trainTestSplit.TrainSet;
            var testData = trainTestSplit.TestSet;

            // 4. Создание пайплайна обработки данных
            var dataProcessingPipeline = mlContext.Transforms
                .Concatenate("Features",
                    nameof(BikeRentalData.Season),
                    nameof(BikeRentalData.Month),
                    nameof(BikeRentalData.Hour),
                    nameof(BikeRentalData.Holiday),
                    nameof(BikeRentalData.Weekday),
                    nameof(BikeRentalData.WorkingDay),
                    nameof(BikeRentalData.WeatherCondition),
                    nameof(BikeRentalData.Temperature),
                    nameof(BikeRentalData.Humidity),
                    nameof(BikeRentalData.Windspeed))
                .Append(mlContext.Transforms.NormalizeMinMax("Features"));

            // 5. Обучение моделей и выбор лучшей
            // Пробуем три разных алгоритма
            var trainers = new (string Name, IEstimator<ITransformer> Estimator)[]
            {
                ("FastTree", mlContext.BinaryClassification.Trainers.FastTree()),
                ("LightGBM", mlContext.BinaryClassification.Trainers.LightGbm()),
                ("LogisticRegression", mlContext.BinaryClassification.Trainers.LbfgsLogisticRegression())
            };

            Console.WriteLine("Обучение и оценка моделей:");
            Console.WriteLine("-------------------------");

            var bestModel = (Name: "", Model: (ITransformer)null, Metrics: (F1Score: 0.0, AUC: 0.0));

            foreach (var trainer in trainers)
            {
                // Создание пайплайна с текущим алгоритмом
                var trainingPipeline = dataProcessingPipeline.Append(trainer.Estimator);

                // Обучение модели
                var model = trainingPipeline.Fit(trainData);

                // Оценка модели
                var predictions = model.Transform(testData);
                var metrics = mlContext.BinaryClassification.Evaluate(
                    data: predictions,
                    labelColumnName: "Label");

                Console.WriteLine($"Модель: {trainer.Name}");
                Console.WriteLine($"  F1-Score: {metrics.F1Score:F4}");
                Console.WriteLine($"  AUC: {metrics.AreaUnderRocCurve:F4}");
                Console.WriteLine();

                // Проверяем, является ли текущая модель лучшей
                if (metrics.F1Score > bestModel.Metrics.F1Score)
                {
                    bestModel = (trainer.Name, model, (metrics.F1Score, metrics.AreaUnderRocCurve));
                }
            }

            Console.WriteLine($"Лучшая модель: {bestModel.Name}");
            Console.WriteLine($"  F1-Score: {bestModel.Metrics.F1Score:F4}");
            Console.WriteLine($"  AUC: {bestModel.Metrics.AUC:F4}");
            Console.WriteLine();

            // 6. Сохранение лучшей модели
            mlContext.Model.Save(bestModel.Model, trainData.Schema, "C:\\Users\\User\\Documents\\Visual Studio 2022\\bikeSharingApp\\Data\\best_model.zip");

            // 7. Выполнение предсказаний на новых примерах
            var predictionEngine = mlContext.Model.CreatePredictionEngine<BikeRentalData, RentalTypePrediction>(bestModel.Model);

            // Примеры для предсказания
            var testExamples = new BikeRentalData[]
            {
                new BikeRentalData
                {
                    Season = 3, 
                    Month = 7,  
                    Hour = 8,    
                    Holiday = 0,
                    Weekday = 2, 
                    WorkingDay = 1,
                    WeatherCondition = 1, 
                    Temperature = 25,
                    Humidity = 60,
                    Windspeed = 10
                },
                new BikeRentalData
                {
                    Season = 1,
                    Month = 1, 
                    Hour = 18,  
                    Holiday = 0,
                    Weekday = 5,  
                    WorkingDay = 1,
                    WeatherCondition = 2,
                    Temperature = -5,
                    Humidity = 85,
                    Windspeed = 15
                }
            };

            Console.WriteLine("Примеры предсказаний:");
            Console.WriteLine("--------------------");

            foreach (var example in testExamples)
            {
                var prediction = predictionEngine.Predict(example);
                Console.WriteLine($"Сезон: {example.Season}, Месяц: {example.Month}, Час: {example.Hour}");
                Console.WriteLine($"Погода: {example.WeatherCondition}, Температура: {example.Temperature}°C");
                Console.WriteLine($"Прогноз: {(prediction.PredictedRentalType ? "Долгосрочная" : "Краткосрочная")} аренда");
                Console.WriteLine($"Вероятность: {prediction.Probability:P2}");
                Console.WriteLine();
            }

            Console.WriteLine("Нажмите любую клавишу для завершения...");
            Console.ReadKey();
        }
    }
}