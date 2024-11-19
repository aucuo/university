package com.example.lab1

import android.os.Bundle
import androidx.activity.ComponentActivity
import androidx.activity.compose.setContent
import androidx.compose.foundation.layout.fillMaxSize
import androidx.compose.material3.Surface
import androidx.compose.material3.Text
import androidx.compose.runtime.Composable
import androidx.compose.ui.Modifier
import androidx.compose.ui.tooling.preview.Preview
import com.example.lab1.ui.theme.LAB1Theme
import android.widget.Toast
import androidx.compose.foundation.background
import androidx.compose.foundation.layout.Arrangement
import androidx.compose.foundation.layout.Column
import androidx.compose.foundation.layout.Spacer
import androidx.compose.foundation.layout.height
import androidx.compose.foundation.layout.padding
import androidx.compose.foundation.layout.width
import androidx.compose.material3.Button
import androidx.compose.material3.ButtonDefaults
import androidx.compose.ui.Alignment
import androidx.compose.ui.graphics.Color
import androidx.compose.ui.res.colorResource
import androidx.compose.ui.res.stringResource
import androidx.compose.ui.unit.dp
import androidx.compose.ui.unit.sp
import java.util.Locale


class MainActivity : ComponentActivity() {
    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContent {
            LAB1Theme {
                Surface(
                    modifier = Modifier.fillMaxSize()
                        .background(colorResource(R.color.bkg_color1)),
                    color = colorResource(R.color.bkg_color1),
                    contentColor = colorResource(R.color.text_color)
                ) {
                    Column(
                        modifier = Modifier
                            .fillMaxSize()
                            .padding(16.dp),
                        verticalArrangement = Arrangement.Center,
                        horizontalAlignment = Alignment.CenterHorizontally
                    ) {

                        LanguageCheck()

                        Spacer(
                            modifier = Modifier
                                .height(10.dp)
                        )

                        Button(
                            onClick = { onClick() },
                            colors = ButtonDefaults.buttonColors(
                                containerColor = colorResource(R.color.bkg_color2)
                            )
                        ) {
                            Text("KNOPKA")
                        }
                    }
                }
            }
        }
    }
    override fun onStart() {
        super.onStart()
        Toast.makeText(applicationContext, "onStart", Toast.LENGTH_SHORT).show()
    }
    override fun onRestart() {
        super.onRestart()
        Toast.makeText(applicationContext, "onRestart", Toast.LENGTH_SHORT).show()
    }
    override fun onPause() {
        super.onPause()
        Toast.makeText(applicationContext, "onPause", Toast.LENGTH_SHORT).show()
    }

    private fun onClick() {
        Toast.makeText(applicationContext, "onClick", Toast.LENGTH_SHORT).show()
    }
    @Composable
    private fun LanguageCheck()
    {
        val lang = Locale.getDefault().getLanguage()
        if(lang.contentEquals("ru"))
        {
            Text(
                text = stringResource(R.string.hello_ru),
                fontSize = 24.sp,
                modifier = Modifier.background(colorResource(R.color.bkg_color2)),
            )
        }
        else
        {
            Text(
                text = stringResource(R.string.hello_eng),
                fontSize = 24.sp,
                modifier = Modifier.background(colorResource(R.color.bkg_color2)),
            )
        }
    }
}