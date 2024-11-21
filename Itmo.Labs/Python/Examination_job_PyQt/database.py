import mysql.connector
from mysql.connector import Error


class Database:
    """Класс для работы с базой данных MySQL."""

    def __init__(self, host,  database, user, password,):
        """Инициализация соединения с базой данных."""
        try:
            self.connection = mysql.connector.connect(
                host=host,
                database=database,
                user=user,
                password=password
            )
            if self.connection.is_connected():
                self.cursor = self.connection.cursor()
                print("Подключение к базе данных успешно установлено.")
        except Error as e:
            print(f"Ошибка подключения к базе данных: {e}")
            self.connection = None

    def get_airports(self, min_lat, max_lat, min_lon, max_lon):
        """Получение аэропортов по заданным координатам."""
        if self.connection is None:
            print("Нет соединения с базой данных.")
            return []

        query = """
        SELECT city, country, latitude, longitude FROM airports
        WHERE latitude BETWEEN %s AND %s AND longitude BETWEEN %s AND %s
        """
        try:
            self.cursor.execute(query, (min_lat, max_lat, min_lon, max_lon))
            return self.cursor.fetchall()
        except Error as e:
            print(f"Ошибка при выполнении запроса: {e}")
            return []

    def close(self):
        """Закрытие соединения с базой данных."""
        if self.connection.is_connected():
            self.cursor.close()
            self.connection.close()
            print("Соединение с базой данных закрыто.")