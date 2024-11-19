package com.example.pms2;

import android.content.Intent;
import android.os.Bundle;
import android.view.View;
import android.widget.EditText;
import android.widget.Toast;

import androidx.appcompat.app.AppCompatActivity;

public class SignInActivity extends AppCompatActivity {
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.sign_in);
    }
    public void onSignUpButtonClick(View view) {
        Intent intent = new Intent(this, SignUpActivity.class);
        startActivity(intent);
    }

    public void onSignInClick(View view) {
        try {
            EditText editTextLogin = findViewById(R.id.editTextLogin);
            EditText editTextPassword = findViewById(R.id.editTextPassword);

            String login = editTextLogin.getText().toString();
            String password = editTextPassword.getText().toString();

            DatabaseHelper dbHelper = new DatabaseHelper(this);
            boolean authorized = dbHelper.authorize(login, password);

            if (authorized) {
                Toast.makeText(this, "Vse cool!!!!", Toast.LENGTH_SHORT).show();
                redirectToMain(login);
            } else {
                Toast.makeText(this, "Ne =)))", Toast.LENGTH_SHORT).show();
            }
        } catch (Exception e) {
            Toast.makeText(this, "Exception: " + e.getMessage(), Toast.LENGTH_SHORT).show();
            e.printStackTrace();
        }
    }

    public void redirectToSignUp(View view) {
        Intent intent = new Intent(this, SignUpActivity.class);
        startActivity(intent);
    }

    public void redirectToMain(String userLogin) {
        Intent intent = new Intent(this, MainActivity.class);
        intent.putExtra("userLogin", userLogin);
        startActivity(intent);
    }
}
