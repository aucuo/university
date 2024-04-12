#include <gtk/gtk.h>

static GtkWidget *progress_bar;
static GtkWidget *cancel_button;

// функция для таймера
static gboolean update_progress(gpointer data) {
    double new_value = gtk_progress_bar_get_fraction(GTK_PROGRESS_BAR(progress_bar)) + 0.01;
    gtk_progress_bar_set_fraction(GTK_PROGRESS_BAR(progress_bar), new_value);

    if (new_value >= 1.0) {
        gtk_widget_set_sensitive(cancel_button, FALSE);

        GtkWidget *complete_window = gtk_window_new(GTK_WINDOW_TOPLEVEL);
        GtkWidget *label = gtk_label_new("Программа установлена!");
        gtk_container_add(GTK_CONTAINER(complete_window), label);
        gtk_widget_show_all(complete_window);

        return FALSE;
    }

    return TRUE;
}

// для отмены
static void cancel_button_clicked(GtkWidget *widget, gpointer data) {
    g_source_remove_by_user_data(data);
    GtkWidget *complete_window = gtk_window_new(GTK_WINDOW_TOPLEVEL);
        GtkWidget *label = gtk_label_new("отмена установки!");
        gtk_container_add(GTK_CONTAINER(complete_window), label);
        gtk_widget_show_all(complete_window);
}

int main(int argc, char *argv[]) {
    GtkWidget *window;
    GtkWidget *box;

    gtk_init(&argc, &argv);
    
    window = gtk_window_new(GTK_WINDOW_TOPLEVEL);
    gtk_window_set_title(GTK_WINDOW(window), "Установка программы");
    g_signal_connect(window, "destroy", G_CALLBACK(gtk_main_quit), NULL);

    // гор.контейнер
    box = gtk_box_new(GTK_ORIENTATION_VERTICAL, 5);
    gtk_container_add(GTK_CONTAINER(window), box);

    // прогресс
    progress_bar = gtk_progress_bar_new();
    gtk_box_pack_start(GTK_BOX(box), progress_bar, TRUE, TRUE, 0);

    // отмена
    cancel_button = gtk_button_new_with_label("Отмена");
    g_signal_connect(cancel_button, "clicked", G_CALLBACK(cancel_button_clicked), NULL);
    gtk_box_pack_start(GTK_BOX(box), cancel_button, FALSE, FALSE, 0);

    gtk_widget_show_all(window);

    g_timeout_add(100, update_progress, NULL);
    gtk_main();

    return 0;
}
