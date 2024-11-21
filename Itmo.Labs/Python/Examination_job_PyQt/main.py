import sys
from PyQt6 import QtWidgets, uic
from views import MainWindow
from database import Database
from controllers import Controller
from models import Airport


def main():
    app = QtWidgets.QApplication(sys.argv)
    db = Database("localhost",  "flights","Air_Tom", "Hochu1Mln$",)
    controller = Controller(db)

    window = MainWindow(controller)
    window.show()

    # Закрываем соединение с базой данных при выходе из приложения
    app.aboutToQuit.connect(db.close)
    sys.exit(app.exec())

if __name__ == "__main__":
    main()
