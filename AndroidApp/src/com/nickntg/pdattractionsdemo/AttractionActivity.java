package com.nickntg.pdattractionsdemo;

import android.app.Activity;
import android.app.AlertDialog;
import android.content.Intent;
import android.os.Bundle;
import android.view.View;
import android.widget.TextView;

/**
 * This activity shows info about the selected attraction
 * and allows the user to query more information about
 * selected guides.
 *  
 * @author nick
 *
 */
public class AttractionActivity extends Activity {
	
    @Override
    public void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.attraction);
        
        // Set the text view to the attraction description.
        TextView tv = (TextView)findViewById(R.id.attractionText);
        tv.setText(AttractionHelper.getDescription());
    }
    
    // Handle hotels guides.
    public void ClickHotels (View v)
    {
    	LaunchWebView(getString(R.string.hotels_text), "Δεν υπάρχουν πληροφορίες ξενοδοχείων για τον προορισμό");
    }
    
    // Handle restaurant guides.
    public void ClickRestaurants (View v)
    {
    	LaunchWebView(getString(R.string.restaurants_text), "Δεν υπάρχουν πληροφορίες εστιατορίων για τον προορισμό");
    }
    
    // Handle entertainment guides.
    public void ClickEntertainment (View v)
    {
    	LaunchWebView(getString(R.string.entertainment_text), "Δεν υπάρχουν πληροφορίες διασκέδασης για τον προορισμό");
    }
 
    // Handle transport guides.
    public void ClickTransport (View v)
    {
    	LaunchWebView(getString(R.string.transport_text), "Δεν υπάρχουν πληροφορίες μετακίνησης για τον προορισμό");
    }
 
    // Handle beaches guides.
    public void ClickBeaches (View v)
    {
    	LaunchWebView(getString(R.string.beaches_text), "Δεν υπάρχουν πληροφορίες παραλιών για τον προορισμό");
    }
       
    // Handle telephone guides.
    public void ClickTelephones (View v)
    {
    	LaunchWebView(getString(R.string.telephones_text), "Δεν υπάρχουν πληροφορίες τηλεφώνων για τον προορισμό");
    }
    
    // Get a guide url and launch the web view activity.
    private void LaunchWebView(String guide, String error)
    {
    	String url = AttractionHelper.GetGuideUrl(guide);
    	
    	if (url == null)
    	{
    		ShowMessage(error);
    	}
    	else
    	{
    		AttractionHelper.setGuideUrl(url);
    		startActivity(new Intent (this, GuideActivity.class));
    	}
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