from PyQt6 import QtWidgets, uic


class MainWindow(QtWidgets.QMainWindow):
    """Главное окно приложения."""

    def __init__(self, controller):
        super().__init__()
        uic.loadUi("mainwindow.ui", self)  # Загружаем интерфейс из файла .ui
        self.controller = controller  # Сохраняем контроллер


    def init_ui(self):
        """Инициализация пользовательского интерфейса."""
        self.apply_filter.clicked.connect(self.apply_filter)
        self.airport_table.setColumnCount(4)
        self.airport_table.setHorizontalHeaderLabels(["Город", "Страна", "Широта", "Долгота"])

    def apply_filter(self):
        """Применение фильтра по широте и долготе."""
        try:
            min_lat = float(self.min_lat_input.text())
            max_lat = float(self.max_lat_input.text())
            min_lon = float(self.min_lon_input.text())
            max_lon = float(self.max_lon_input.text())

            airports = self.controller.get_filtered_airports(min_lat, max_lat, min_lon, max_lon)
            self.airport_table.setRowCount(len(airports))

            for row_index, airport in enumerate(airports):
                self.airport_table.setItem(row_index, 0, QtWidgets.QTableWidgetItem(airport.city))
                self.airport_table.setItem(row_index, 1, QtWidgets.QTableWidgetItem(airport.country))
                self.airport_table.setItem(row_index, 2, QtWidgets.QTableWidgetItem(str(airport.latitude)))
                self.airport_table.setItem(row_index, 3, QtWidgets.QTableWidgetItem(str(airport.longitude)))
        except ValueError:
            QtWidgets.QMessageBox.warning(self, "Ошибка ввода", "Пожалуйста, введите корректные числовые значения.")