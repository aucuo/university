#include <gtk/gtk.h>

// Функция, которая будет вызвана при нажатии мышкой
void on_window_clicked(GtkWidget *widget, GdkEventButton *event, gpointer data) {
    // Создаем диалоговое окно с сообщением
    GtkWidget *dialog = gtk_message_dialog_new(GTK_WINDOW(widget),
                                               GTK_DIALOG_DESTROY_WITH_PARENT,
                                               GTK_MESSAGE_ERROR,
                                               GTK_BUTTONS_OK,
                                               "Произошла ошибка! Программа будет закрыта!");
    // Ожидаем нажатие кнопки OK и закрываем приложение
    gtk_dialog_run(GTK_DIALOG(dialog));
    gtk_widget_destroy(dialog);
    gtk_main_quit();
}

int main(int argc, char *argv[]) {
    // Инициализация GTK
    gtk_init(&argc, &argv);

    // Создаем главное окно
    GtkWidget *window = gtk_window_new(GTK_WINDOW_TOPLEVEL);
    g_signal_connect(window, "destroy", G_CALLBACK(gtk_main_quit), NULL);

    // Устанавливаем обработчик события "клик мышью"
    g_signal_connect(window, "button-press-event", G_CALLBACK(on_window_clicked), NULL);

    // Отображаем все виджеты
    gtk_widget_show_all(window);

    // Запускаем цикл обработки событий
    gtk_main();

    return 0;
}
