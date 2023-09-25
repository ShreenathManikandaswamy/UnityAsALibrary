package com.shreenath.nativeandroid

import androidx.appcompat.app.AppCompatActivity
import android.os.Bundle

class MainActivity : AppCompatActivity() {
    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.activity_main)

        val intent = android.content.Intent(this, UnityHandlerActivity::class.java)
        startActivity(intent)
    }
}