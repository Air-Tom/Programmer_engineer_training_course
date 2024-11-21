from models import Airport


class Controller:
    """Контроллер для управления логикой приложения."""

    def __init__(self, db):
        self.db = db

    def get_filtered_airports(self, min_lat, max_lat, min_lon, max_lon):
        """Получение отфильтрованных аэропортов."""
        results = self.db.get_airports(min_lat, max_lat, min_lon, max_lon)
        return [Airport(*result) for result in results]
