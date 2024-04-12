#include <gtk/gtk.h>
#include <math.h>

GtkWidget *window;
GtkWidget *drawing_area;

gdouble square_x = 50;
gdouble square_y = 50;
gdouble target_x = 50;
gdouble target_y = 50;

gboolean move_square(gpointer data) {
    // Рассчитываем расстояние и скорость для перемещения
    gdouble dx = target_x - square_x;
    gdouble dy = target_y - square_y;
    gdouble distance = sqrt(dx*dx + dy*dy);

    if (distance > 1) {
        gdouble speed = 2; // Установите желаемую скорость перемещения
        square_x += (dx / distance) * speed;
        square_y += (dy / distance) * speed;

        // Обновляем виджет
        gtk_widget_queue_draw(drawing_area);
    }

    // Проверяем, достигли ли цели
    if (fabs(square_x - target_x) < 1 && fabs(square_y - target_y) < 1) {
        return FALSE; // Завершаем таймер
    }

    return TRUE; // Продолжаем таймер
}

gboolean on_draw(GtkWidget *widget, cairo_t *cr, gpointer data) {
    // Рисуем квадратик
    cairo_set_source_rgb(cr, 0, 0, 0);
    cairo_rectangle(cr, square_x, square_y, 10, 10);
    cairo_fill(cr);

    return FALSE;
}

void on_click(GtkWidget *widget, GdkEventButton *event, gpointer data) {
    // Устанавливаем новую цель для квадратика
    target_x = event->x - 5;
    target_y = event->y - 5;

    // Запускаем таймер
    g_timeout_add(16, move_square, NULL);
}

int main(int argc, char *argv[]) {
    gtk_init(&argc, &argv);

    window = gtk_window_new(GTK_WINDOW_TOPLEVEL);
    g_signal_connect(window, "destroy", G_CALLBACK(gtk_main_quit), NULL);
    gtk_window_set_default_size(GTK_WINDOW(window), 800, 600);

    drawing_area = gtk_drawing_area_new();
    gtk_container_add(GTK_CONTAINER(window), drawing_area);
    g_signal_connect(G_OBJECT(drawing_area), "draw", G_CALLBACK(on_draw), NULL);
    g_signal_connect(G_OBJECT(window), "button-press-event", G_CALLBACK(on_click), NULL);

    gtk_widget_show_all(window);

    gtk_main();

    return 0;
}
