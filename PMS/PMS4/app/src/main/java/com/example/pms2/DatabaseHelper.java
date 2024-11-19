package com.example.pms2;

import android.content.ContentValues;
import android.content.Context;
import android.database.Cursor;
import android.database.sqlite.SQLiteDatabase;
import android.database.sqlite.SQLiteOpenHelper;

import java.util.ArrayList;
import java.util.List;

public class DatabaseHelper extends SQLiteOpenHelper {
    private static final String DATABASE_NAME = "mydatabase.db";
    private static final int DATABASE_VERSION = 1;
    //USERS/////////////////////////////////////////////////////////////////////////////////////////
    private static final String TABLE_USERS = "users";
    private static final String USER_COLUMN_ID = "id";
    private static final String USER_COLUMN_LOGIN = "login";
    private static final String USER_COLUMN_PASSWORD = "password";
    //TICKETS///////////////////////////////////////////////////////////////////////////////////////
    private static final String TABLE_TICKETS = "tickets";
    private static final String TICKET_COLUMN_ID = "id";
    private static final String TICKET_COLUMN_DIRECTION_FROM = "direction_from";
    private static final String TICKET_COLUMN_DIRECTION_TO = "direction_to";
    private static final String TICKET_COLUMN_PRICE = "price";
    public DatabaseHelper(Context context) {
        super(context, DATABASE_NAME, null, DATABASE_VERSION);
    }
    @Override
    public void onCreate(SQLiteDatabase db) {
        String createUserTableQuery = "CREATE TABLE " + TABLE_USERS +
                "(" + USER_COLUMN_ID + " INTEGER PRIMARY KEY AUTOINCREMENT, " +
                USER_COLUMN_LOGIN + " TEXT, " +
                USER_COLUMN_PASSWORD + " TEXT)";
        db.execSQL(createUserTableQuery);

        String createTicketTableQuery = "CREATE TABLE " + TABLE_TICKETS +
                "(" + TICKET_COLUMN_ID + " INTEGER PRIMARY KEY AUTOINCREMENT, " +
                TICKET_COLUMN_DIRECTION_FROM + " TEXT, " +
                TICKET_COLUMN_DIRECTION_TO + " TEXT, " +
                TICKET_COLUMN_PRICE + " TEXT)";
        db.execSQL(createTicketTableQuery);

        createTicketsRecords(db);
    }
    @Override
    public void onUpgrade(SQLiteDatabase db, int oldVersion, int newVersion) {
        String dropTableUsersQuery = "DROP TABLE IF EXISTS " + TABLE_USERS;
        db.execSQL(dropTableUsersQuery);
        String dropTableTicketsQuery = "DROP TABLE IF EXISTS " + TABLE_TICKETS;
        db.execSQL(dropTableTicketsQuery);
        onCreate(db);
    }
    private void createTicketsRecords(SQLiteDatabase db) {
        ContentValues ticketValues = new ContentValues();
        ticketValues.put(TICKET_COLUMN_DIRECTION_FROM, "Miory");
        ticketValues.put(TICKET_COLUMN_DIRECTION_TO, "Novopolotsk");
        ticketValues.put(TICKET_COLUMN_PRICE, 9.30);
        db.insert(TABLE_TICKETS, null, ticketValues);

        ticketValues.clear();

        ticketValues.put(TICKET_COLUMN_DIRECTION_FROM, "Verhnedvinsk");
        ticketValues.put(TICKET_COLUMN_DIRECTION_TO, "Ropno");
        ticketValues.put(TICKET_COLUMN_PRICE, 2.27);
        db.insert(TABLE_TICKETS, null, ticketValues);

        ticketValues.clear();

        ticketValues.put(TICKET_COLUMN_DIRECTION_FROM, "Polotsk");
        ticketValues.put(TICKET_COLUMN_DIRECTION_TO, "Miory");
        ticketValues.put(TICKET_COLUMN_PRICE, 8.20);
        db.insert(TABLE_TICKETS, null, ticketValues);

        ticketValues.clear();

        ticketValues.put(TICKET_COLUMN_DIRECTION_FROM, "Miory");
        ticketValues.put(TICKET_COLUMN_DIRECTION_TO, "Verhnedvinsk");
        ticketValues.put(TICKET_COLUMN_PRICE, 4.95);
        db.insert(TABLE_TICKETS, null, ticketValues);

        ticketValues.clear();

        ticketValues.put(TICKET_COLUMN_DIRECTION_FROM, "Polotsk");
        ticketValues.put(TICKET_COLUMN_DIRECTION_TO, "Minsk");
        ticketValues.put(TICKET_COLUMN_PRICE, 15.00);
        db.insert(TABLE_TICKETS, null, ticketValues);

        ticketValues.clear();

        ticketValues.put(TICKET_COLUMN_DIRECTION_FROM, "Glubokoe");
        ticketValues.put(TICKET_COLUMN_DIRECTION_TO, "Naroch");
        ticketValues.put(TICKET_COLUMN_PRICE, 12.35);
        db.insert(TABLE_TICKETS, null, ticketValues);

        ticketValues.clear();

        ticketValues.put(TICKET_COLUMN_DIRECTION_FROM, "Smolevichi");
        ticketValues.put(TICKET_COLUMN_DIRECTION_TO, "Kopachi");
        ticketValues.put(TICKET_COLUMN_PRICE, 34.12);
        db.insert(TABLE_TICKETS, null, ticketValues);

        ticketValues.clear();

        ticketValues.put(TICKET_COLUMN_DIRECTION_FROM, "Vitebsk");
        ticketValues.put(TICKET_COLUMN_DIRECTION_TO, "Braslav");
        ticketValues.put(TICKET_COLUMN_PRICE, 20.50);
        db.insert(TABLE_TICKETS, null, ticketValues);

        ticketValues.clear();

        ticketValues.put(TICKET_COLUMN_DIRECTION_FROM, "Minsk");
        ticketValues.put(TICKET_COLUMN_DIRECTION_TO, "Vitebsk");
        ticketValues.put(TICKET_COLUMN_PRICE, 14.70);
        db.insert(TABLE_TICKETS, null, ticketValues);

        ticketValues.clear();

        ticketValues.put(TICKET_COLUMN_DIRECTION_FROM, "Miory");
        ticketValues.put(TICKET_COLUMN_DIRECTION_TO, "Odessa");
        ticketValues.put(TICKET_COLUMN_PRICE, 250.40);
        db.insert(TABLE_TICKETS, null, ticketValues);

        ticketValues.clear();

        ticketValues.put(TICKET_COLUMN_DIRECTION_FROM, "Moscow");
        ticketValues.put(TICKET_COLUMN_DIRECTION_TO, "Miory");
        ticketValues.put(TICKET_COLUMN_PRICE, 0.99);
        db.insert(TABLE_TICKETS, null, ticketValues);
    }

    //USERS/////////////////////////////////////////////////////////////////////////////////////////
    public long addUser(String login, String password) {
        SQLiteDatabase db = this.getWritableDatabase();
        ContentValues values = new ContentValues();
        values.put(USER_COLUMN_LOGIN, login);
        values.put(USER_COLUMN_PASSWORD, password);
        long id = db.insert(TABLE_USERS, null, values);
        db.close();
        return id;
    }
    public void updateUser(int id, String login, String password) {
        SQLiteDatabase db = this.getWritableDatabase();

        ContentValues values = new ContentValues();
        values.put(USER_COLUMN_LOGIN, login);
        values.put(USER_COLUMN_PASSWORD, password);
        db.update(TABLE_USERS, values, USER_COLUMN_ID + " = ?", new
                String[]{String.valueOf(id)});
        db.close();
    }
    public void deleteUser(String login) {
        SQLiteDatabase db = this.getWritableDatabase();
        db.delete(TABLE_USERS, USER_COLUMN_LOGIN + " = ?", new
                String[]{String.valueOf(login)});
        db.close();
    }
    public boolean authorize(String login, String password) {
        String selectQuery = "SELECT * FROM " + TABLE_USERS + " WHERE " + USER_COLUMN_LOGIN + " = ?";
        SQLiteDatabase db = this.getWritableDatabase();
        Cursor cursor = db.rawQuery(selectQuery, new String[]{login});

        boolean authorized = false;

        if (cursor.moveToFirst()) {
            String storedPassword = cursor.getString(cursor.getColumnIndex(USER_COLUMN_PASSWORD));
            if (password.equals(storedPassword)) {
                authorized = true;
            }
        }

        cursor.close();
        db.close();

        return authorized;
    }
    public List<User> getAllUsers() {
        List<User> users = new ArrayList<>();
        String selectQuery = "SELECT * FROM " + TABLE_USERS;
        SQLiteDatabase db = this.getWritableDatabase();
        Cursor cursor = db.rawQuery(selectQuery, null);
        if (cursor.moveToFirst()) {
            do {
                int id = cursor.getInt(cursor.getColumnIndex(USER_COLUMN_ID));
                String login =
                        cursor.getString(cursor.getColumnIndex(USER_COLUMN_LOGIN));
                String password =
                        cursor.getString(cursor.getColumnIndex(USER_COLUMN_PASSWORD));
                User contact = new User(id, login, password);
                users.add(contact);
            } while (cursor.moveToNext());
        }
        cursor.close();
        db.close();
        return users;
    }
    //TICKETS/////////////////////////////////////////////////////////////////////////////////////////
    public List<Ticket> getAllTickets() {
        List<Ticket> tickets = new ArrayList<>();
        String selectQuery = "SELECT * FROM " + TABLE_TICKETS;
        SQLiteDatabase db = this.getWritableDatabase();
        Cursor cursor = db.rawQuery(selectQuery, null);
        if (cursor.moveToFirst()) {
            do {
                int id = cursor.getInt(cursor.getColumnIndex(TICKET_COLUMN_ID));
                String directionFrom = cursor.getString(cursor.getColumnIndex(TICKET_COLUMN_DIRECTION_FROM));
                String directionTo = cursor.getString(cursor.getColumnIndex(TICKET_COLUMN_DIRECTION_TO));
                double price = cursor.getDouble(cursor.getColumnIndex(TICKET_COLUMN_PRICE));
                Ticket ticket = new Ticket(id, directionFrom, directionTo, price);
                tickets.add(ticket);
            } while (cursor.moveToNext());
        }
        cursor.close();
        db.close();
        return tickets;
    }
    public long addTicket(String direction_from, String direction_to, double price) {
        SQLiteDatabase db = this.getWritableDatabase();
        ContentValues values = new ContentValues();
        values.put(TICKET_COLUMN_DIRECTION_FROM, direction_from);
        values.put(TICKET_COLUMN_DIRECTION_TO, direction_to);
        values.put(TICKET_COLUMN_PRICE, price);
        long id = db.insert(TABLE_TICKETS, null, values);
        db.close();
        return id;
    }
}