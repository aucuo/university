public class DatabaseAdapter {
    private static final String DATABASE_NAME = "SampleDatabase.db";

    private static final String DATABASE_TABLE = "SampleTable";
    private static final int DATABASE_VERSION = 1;
// Имя поля индекса для
    public static final String KEY_ID = "_id";
// Название и номер п/п (индекс) каждого поля
    public static final String KEY_NAME = "name";
    public static final int NAME_COLUMN = 1;
// Для каждого поля опишите константы аналогичным образом...
// SQL-запрос для создания БД
    private static final String DATABASE_CREATE = "create table "
    + DATABASE_TABLE + " (" + KEY_ID
    + " integer primary key autoincrement, " + KEY_NAME
    + " text not null);";
// Переменная для хранения объекта БД
    private SQLiteDatabase db;
// Контекст приложения для
    private final Context context;
// Экземпляр вспомогательного класса для открытия и обновления БД
    private myDbHelper dbHelper;
// Конструктор
    public SampleDBAdapter(Context _context) {
        context = _context;
        dbHelper = new myDbHelper(context, DATABASE_NAME, null,
        DATABASE_VERSION);

    }
// «Открывашка» БД
    public SampleDBAdapter open() throws SQLException {
        try {
            db = dbHelper.getWritableDatabase();
        } catch (SQLiteException e) {
            db = dbHelper.getReadableDatabase();
        }
        return this;
    }
// Метод для закрытия БД
    public void close() {
        db.close();
    }
// Метод для добавления данных, возвращает индекс
// свежевставленного объекта
    public long insertEntry(SampleObject _SampleObject) {
// Здесь создается объект ContentValues, содержащий
// нужные поля и производится вставка
        return index;
    }
// Метод для удаления строки таблицы по индексу
    public boolean removeEntry(long _rowIndex) {
        return db.delete(DATABASE_TABLE, KEY_ID + "=" + _rowIndex, null) &gt; 0;
    }
// Метод для получения всех данных.
// Возвращает курсор, который можно использовать для
// привязки к адаптерам типа SimpleCursorAdapter
    public Cursor getAllEntries() {
        return db.query(DATABASE_TABLE, new String[] { KEY_ID, KEY_NAME },
            null, null, null, null, null);

    }
// Возвращает экземпляр объекта по индексу
    public SampleObject getEntry(long _rowIndex) {
// Получите курсор, указывающий на нужные данные из БД
// и создайте новый объект, используя этими данными
// Если ничего не найдено, верните null
        return objectInstance;
    }
// Изменяет объект по индексу

// Увы, это не ORM :(
    public boolean updateEntry(long _rowIndex, SampleObject _SampleObject) {
// Создайте объект ContentValues на основе свойств SampleObject
// и используйте его для обновления строки в таблице
        return true; // Если удалось обновить, иначе false :)
    }
// Вспомогательный класс для открытия и обновления БД
    private static class myDbHelper extends SQLiteOpenHelper {
        public myDbHelper(Context context, String name,
        CursorFactory factory, int version) {
            super(context, name, factory, version);
        }
// Вызывается при необходимости создания БД
        @Override
        public void onCreate(SQLiteDatabase _db) {
            _db.execSQL(DATABASE_CREATE);
        }
// Вызывается для обновления БД, когда текущая версия БД
// в приложении новее, чем у БД на диске
        @Override
        public void onUpgrade(SQLiteDatabase _db, int _oldVersion,

            int _newVersion) {
// Выдача сообщения в журнал, полезно при отладке
            Log.w("TaskDBAdapter", "Upgrading from version " + _oldVersion
            + " to " + _newVersion
            + ", which will destroy all old data");
// Обновляем БД до новой версии.
// В простейшем случае убиваем старую БД
// и заново создаем новую.
// В реальной жизни стоит подумать о пользователях
// вашего приложения и их реакцию на потерю старых данных.
            _db.execSQL("DROP TABLE IF EXISTS " + DATABASE_TABLE);
            onCreate(_db);
        }
    }
}