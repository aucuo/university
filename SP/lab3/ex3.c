#include <gtk/gtk.h>

int min = 1;
int max = 1000;
int guess;

GtkWidget *window, *label, *buttonYes, *buttonNo, *buttonLess;

void updateGuessLabel() {
    char buffer[50];
    sprintf(buffer, "Ваше число — это %d?", guess);
    gtk_label_set_text(GTK_LABEL(label), buffer);
}

void on_button_clicked(GtkWidget *widget, gpointer data) {
    if (widget == buttonYes) {
        gtk_label_set_text(GTK_LABEL(label), "Ура! Я угадал!");
    } else if (widget == buttonNo) {
        min = guess + 1;
        guess = (min + max) / 2;
        updateGuessLabel();
    } else if (widget == buttonLess) {
        max = guess - 1;
        guess = (min + max) / 2;
        updateGuessLabel();
    }
}

int main(int argc, char *argv[]) {
    gtk_init(&argc, &argv);

    window = gtk_window_new(GTK_WINDOW_TOPLEVEL);
    gtk_window_set_title(GTK_WINDOW(window), "Угадайка");
    g_signal_connect(window, "destroy", G_CALLBACK(gtk_main_quit), NULL);

    label = gtk_label_new("Задумайте число от 1 до 1000!");
    buttonYes = gtk_button_new_with_label("Да");
    buttonNo = gtk_button_new_with_label("Больше");
    buttonLess = gtk_button_new_with_label("Меньше");

    g_signal_connect(buttonYes, "clicked", G_CALLBACK(on_button_clicked), NULL);
    g_signal_connect(buttonNo, "clicked", G_CALLBACK(on_button_clicked), NULL);
    g_signal_connect(buttonLess, "clicked", G_CALLBACK(on_button_clicked), NULL);

    guess = (min + max) / 2;
    updateGuessLabel();

    GtkWidget *box = gtk_box_new(GTK_ORIENTATION_VERTICAL, 10);
    gtk_container_add(GTK_CONTAINER(box), label);
    gtk_container_add(GTK_CONTAINER(box), buttonYes);
    gtk_container_add(GTK_CONTAINER(box), buttonNo);
    gtk_container_add(GTK_CONTAINER(box), buttonLess);
    gtk_container_add(GTK_CONTAINER(window), box);

    gtk_widget_show_all(window);

    gtk_main();

    return 0;
}
