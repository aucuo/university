package com.example.pms2;

import androidx.annotation.NonNull;
import androidx.appcompat.app.AppCompatActivity;

import android.content.ContentValues;
import android.content.Context;
import android.database.Cursor;
import android.database.sqlite.SQLiteDatabase;
import android.os.Bundle;
import android.util.Log;
import android.view.ContextMenu;
import android.view.KeyEvent;
import android.view.MenuInflater;
import android.view.MenuItem;
import android.view.View;
import android.webkit.WebSettings;
import android.webkit.WebView;
import android.widget.AdapterView;
import android.widget.ArrayAdapter;
import android.widget.Button;
import android.widget.CheckBox;
import android.widget.CheckedTextView;
import android.widget.EditText;
import android.widget.ListView;
import android.widget.RadioButton;
import android.widget.TabHost;
import android.widget.TextView;
import android.widget.Toast;
import android.widget.ToggleButton;
import android.view.MenuItem;

import java.util.ArrayList;

public class TabWidjet extends AppCompatActivity  {
    private static final String DATABASE_NAME = "myDatabase.db";
    private static final String DATABASE_TABLE = "mainTable";
    private static final String DATABASE_CREATE = "create table "
            + DATABASE_TABLE + " ( _id integer primary key autoincrement,"
            + "username text not null);";
    SQLiteDatabase myDatabase;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_tab_widjet);

        setTitle("top 1 tabhost");
        TabHost tabHost = (TabHost) findViewById(R.id.tabHost);
        tabHost.setup();
        TabHost.TabSpec tabSpec = tabHost.newTabSpec("tag1");
        //      ----------ВКЛАДКИ------------------------------------------------------------------------------------------------------------------
        tabSpec = tabHost.newTabSpec("tag1");
        tabSpec.setContent(R.id.tab1);
        tabSpec.setIndicator("кнопачьки))))))");
        tabHost.addTab(tabSpec);

        tabSpec = tabHost.newTabSpec("tag2");
        tabSpec.setContent(R.id.tab2);
        tabSpec.setIndicator("база даних))))");
        tabHost.addTab(tabSpec);

        tabHost.setCurrentTab(0);
        //      ----------ЧАСТЬ ЗАДАНИЯ 1------------------------------------------------------------------------------------------------------------------
        //        Button button = (Button)findViewById(R.id.button);
        //        button.setFocusable(true);
        //        button.setFocusableInTouchMode(true);
        //      ----------ЧАСТЬ ЗАДАНИЯ 5------------------------------------------------------------------------------------------------------------------
        final EditText userName = (EditText) findViewById(R.id.user_name);
        userName.setOnKeyListener(new View.OnKeyListener() {
            @Override
            public boolean onKey(View v, int keyCode, KeyEvent event) {
                if ((event.getAction() == KeyEvent.ACTION_DOWN)
                        && (keyCode == KeyEvent.KEYCODE_ENTER)) {
                    Toast.makeText(getApplicationContext(),
                            userName.getText(), Toast.LENGTH_SHORT).show();
                    return true;
                }
                return false;
            }
        });

        //      ----------БАЗЫ-----------------------------------------------------------------------------------------------------------------------------
        //      ----------ДАНИХ----------------------------------------------------------------------------------------------------------------------------
        dropDatabase();
        createDatabase();
        insertData();

        ListView listView = findViewById(R.id.listView);
        ArrayList<String> newData = receiveData();
        ArrayAdapter<String> newAdapter = new ArrayAdapter<>(this, android.R.layout.simple_list_item_1, newData);
        listView.setAdapter(newAdapter);

        listView.setOnItemClickListener(new AdapterView.OnItemClickListener() {
            @Override
            public void onItemClick(AdapterView<?> parent, View view, int position, long id) {
                String selectedItem = (String) parent.getItemAtPosition(position);
                int dataIndex = getIndexFromDatabase(selectedItem);
                Toast.makeText(getApplicationContext(), "Record index: " + dataIndex, Toast.LENGTH_SHORT).show();
            }
        });
        registerForContextMenu(listView);
    }
    private void createDatabase() {
        myDatabase = openOrCreateDatabase(DATABASE_NAME, MODE_PRIVATE, null);
        myDatabase.execSQL(DATABASE_CREATE);
    }
    private void dropDatabase() {
        getApplicationContext().deleteDatabase(DATABASE_NAME);
    }
    private void insertData() {
        ContentValues values = new ContentValues();
        values.put("username", "Sonya");
        myDatabase.insert(DATABASE_TABLE, null, values);

        values.clear();
        values.put("username", "Anna");
        myDatabase.insert(DATABASE_TABLE, null, values);

        values.clear();
        values.put("username", "Hanna");
        myDatabase.insert(DATABASE_TABLE, null, values);
    }
    private ArrayList<String> receiveData() {
        ArrayList<String> data = new ArrayList<>();
        Cursor cursor = myDatabase.query(DATABASE_TABLE, null, null, null, null, null, null);

        if (cursor.moveToFirst()) {
            do {
                String columnOneValue = cursor.getString(cursor.getColumnIndex("username"));
                data.add(columnOneValue);
            } while (cursor.moveToNext());
        }

        cursor.close();
        return data;
    }
    private int getIndexFromDatabase(String selectedItem) {
        int index = -1;
        Cursor cursor = myDatabase.query(DATABASE_TABLE, new String[]{"_id"}, "username=?", new String[]{selectedItem}, null, null, null);
        if (cursor.moveToFirst()) {
            index = cursor.getInt(cursor.getColumnIndex("_id"));
        }
        cursor.close();
        return index;
    }
    @Override
    public void onCreateContextMenu(ContextMenu menu, View v, ContextMenu.ContextMenuInfo menuInfo) {
        super.onCreateContextMenu(menu, v, menuInfo);
        MenuInflater inflater = getMenuInflater();
        inflater.inflate(R.menu.context_menu, menu);
    }
    @Override
    public boolean onContextItemSelected(@NonNull MenuItem item) {
        try {
            AdapterView.AdapterContextMenuInfo info = (AdapterView.AdapterContextMenuInfo) item.getMenuInfo();
            ListView listView = findViewById(R.id.listView);
            String selectedItem = (String) listView.getItemAtPosition(info.position);

            int itemId = item.getItemId();
            if (itemId == R.id.menu_delete) {
                deleteItemFromDatabase(selectedItem);
                refreshData();
                return true;
            } else if(itemId == R.id.menu_edit){
                EditText newUsernameEditText = findViewById(R.id.editTextNewUsername);
                String newUsername = newUsernameEditText.getText().toString();
                editItemFromDatabase(selectedItem, newUsername);
                refreshData();
                return true;
            }
            else {
                return super.onContextItemSelected(item);
            }
        } catch (Exception e) {
            Log.e("YourActivity", "Error in onContextItemSelected", e);
            return false;
        }
    }
    private void deleteItemFromDatabase(String selectedItem) {
        myDatabase.delete(DATABASE_TABLE, "username=?", new String[]{selectedItem});
    }
    private void editItemFromDatabase(String selectedItem, String newUsername) {
        ContentValues values = new ContentValues();
        values.put("username", newUsername);
        int rowsAffected = myDatabase.update(DATABASE_TABLE, values, "username=?", new String[]{selectedItem});

        if (rowsAffected > 0) {
            Toast.makeText(getApplicationContext(), "cool", Toast.LENGTH_SHORT).show();
        } else {
            Toast.makeText(getApplicationContext(), "vse ploho =(", Toast.LENGTH_SHORT).show();
        }
    }
    private void refreshData() {
        ArrayList<String> newData = receiveData();
        ArrayAdapter<String> newAdapter = new ArrayAdapter<>(this, android.R.layout.simple_list_item_1, newData);
        ListView listView = findViewById(R.id.listView);
        listView.setAdapter(newAdapter);
    }
    //----------ЗАДАНИЕ 1------------------------------------------------------------------------------------------------------------------
    public void onButtonClicked(View v) {
        Toast.makeText(this, "Кнопка нажата", Toast.LENGTH_SHORT).show();
    }
    //----------ЗАДАНИЕ 2------------------------------------------------------------------------------------------------------------------
    public void onCheckboxClicked(View v) {
        if (((CheckBox) v).isChecked()) {
            Toast.makeText(this, "Отмечено", Toast.LENGTH_SHORT).show();
        } else {
            Toast.makeText(this, "Не отмечено", Toast.LENGTH_SHORT).show();
        }
    }
    //----------ЗАДАНИЕ 3------------------------------------------------------------------------------------------------------------------
    public void onToggleClicked(View v) {
        if (((ToggleButton) v).isChecked()) {
            Toast.makeText(this, "Включено", Toast.LENGTH_SHORT).show();
        } else {
            Toast.makeText(this, "Выключено", Toast.LENGTH_SHORT).show();
        }
    }
    //----------ЗАДАНИЕ 4------------------------------------------------------------------------------------------------------------------
    public void onRadioButtonClicked(View v) {
        RadioButton rb = (RadioButton) v;
        Toast.makeText(this, "Выбрано животное: " + rb.getText(),
                Toast.LENGTH_SHORT).show();
    }
    //----------ЗАДАНИЕ 5------------------------------------------------------------------------------------------------------------------
}