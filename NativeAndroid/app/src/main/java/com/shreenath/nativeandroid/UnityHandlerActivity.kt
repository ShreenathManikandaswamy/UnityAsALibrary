package com.shreenath.nativeandroid

import androidx.appcompat.app.AppCompatActivity
import android.os.Bundle
import com.unity3d.player.UnityPlayerActivity

class UnityHandlerActivity : AppCompatActivity() {
    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.activity_unity_handler)

        val jeepButton = findViewById<android.widget.Button>(R.id.jeepButton)

        // operations to be performed
        // when user tap on the button
        jeepButton?.setOnClickListener()
        {
            val intent = android.content.Intent(this, UnityPlayerActivity::class.java)
            intent.putExtra("BrandName", "Jeep")
            startActivity(intent)
        }

        val lanciaButton = findViewById<android.widget.Button>(R.id.lanciaButton)

        // operations to be performed
        // when user tap on the button
        lanciaButton?.setOnClickListener()
        {
            val intent = android.content.Intent(this, UnityPlayerActivity::class.java)
            intent.putExtra("BrandName", "Lancia")
            startActivity(intent)
        }
    }
}