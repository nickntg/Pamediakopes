package com.nickntg.pdattractionsdemo;

import android.app.Activity;
import android.app.AlertDialog;
import android.content.Intent;
import android.os.Bundle;
import android.view.View;

/**
 * Main activity.
 * 
 * @author nick
 *
 */
public class MainActivity extends Activity {

    @Override
    public void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.main);
    }
    
    // Launch the attraction selection activity.
    public void ClickAttractions (View v)
    {
    	startActivity(new Intent(this, AttractionsActivity.class));
    }
    
    // Show about.
    public void ClickAbout (View v)
    {
    	ShowMessage("Interview-ware demo for PameDiakopes.");
    }
    
    // Show a message dialogue.
    private void ShowMessage(String msg)
    {
    	AlertDialog.Builder builder = new AlertDialog.Builder(this);
    	builder.setMessage(msg);
    	builder.setCancelable(true);
    	builder.setPositiveButton("OK", null);
    	builder.show();
    }
}