package com.example.pms2;

import android.content.Intent;
import android.os.Bundle;
import android.view.View;
import android.widget.EditText;
import android.widget.Toast;

import androidx.appcompat.app.AppCompatActivity;

public class SignUpActivity extends AppCompatActivity {
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.sign_up);
    }

    public void onSignUpClick(View view) {
        try {
            EditText editTextLogin = findViewById(R.id.editTextLogin);
            EditText editTextPassword = findViewById(R.id.editTextPassword);

            String login = editTextLogin.getText().toString();
            String password = editTextPassword.getText().toString();

            DatabaseHelper dbHelper = new DatabaseHelper(this);
            long userId = dbHelper.addUser(login, password);

            Toast.makeText(this, "Nice password, " + login + "! Your id is " + userId, Toast.LENGTH_SHORT).show();
            Toast.makeText(this, "Come and sign in now!!!!!!" + userId, Toast.LENGTH_SHORT).show();
        } catch (Exception e) {
            Toast.makeText(this, "Exception: " + e.getMessage(), Toast.LENGTH_SHORT).show();
            e.printStackTrace();
        }
    }
    public void redirectToSignIn(View view) {
        Intent intent = new Intent(this, SignInActivity.class);
        startActivity(intent);
    }
}
