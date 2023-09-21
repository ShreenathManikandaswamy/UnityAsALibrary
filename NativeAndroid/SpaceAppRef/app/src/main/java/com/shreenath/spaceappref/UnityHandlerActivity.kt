package com.shreenath.spaceappref

import android.content.Intent
import androidx.appcompat.app.AppCompatActivity
import android.os.Bundle
import android.widget.Button
import com.unity3d.player.UnityPlayerActivity

class UnityHandlerActivity : AppCompatActivity() {
    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.activity_unity_handler)

        val jeepButton = findViewById<Button>(R.id.jeepButton)

        // operations to be performed
        // when user tap on the button
        jeepButton?.setOnClickListener()
        {
            val intent = Intent(this, UnityPlayerActivity::class.java)
            intent.putExtra("Brand", "Jeep")
            startActivity(intent)
        }

        val lanciaButton = findViewById<Button>(R.id.lanciaButton)

        // operations to be performed
        // when user tap on the button
        lanciaButton?.setOnClickListener()
        {
            val intent = Intent(this, UnityPlayerActivity::class.java)
            intent.putExtra("Brand", "Lancia")
            startActivity(intent)
        }
    }
}