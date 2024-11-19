package com.example.pms2;
import android.content.Context;
import android.database.Cursor;
import android.database.SQLException;
import android.database.sqlite.SQLiteDatabase;
import android.database.sqlite.SQLiteOpenHelper;
import android.util.Log;

public class DatabaseAdapter extends SQLiteOpenHelper {
    private static final String DATABASE_NAME = "myDatabase.db";
    private static final int DATABASE_VERSION = 1;
    public static final String DATABASE_TABLE = "mainTable";
    public static final String COLUMN_ID = "_id";
    public static final String COLUMN_USERNAME = "username";

    private static final String DATABASE_CREATE = "create table "
            + DATABASE_TABLE + " ( " + COLUMN_ID + " integer primary key autoincrement,"
            + COLUMN_USERNAME + " text not null);";

    public DatabaseAdapter(Context context) {
        super(context, DATABASE_NAME, null, DATABASE_VERSION);
    }
    @Override
    public void onCreate(SQLiteDatabase db) {
        db.execSQL(DATABASE_CREATE);
    }
    @Override
    public void onUpgrade(SQLiteDatabase db, int oldVersion, int newVersion) {
        Log.w("TaskDBAdapter", "Upgrading from version " + oldVersion
                + " to " + newVersion
                + ", which will destroy all old data");
        db.execSQL("DROP TABLE IF EXISTS " + DATABASE_TABLE);
        onCreate(db);
    }
}
