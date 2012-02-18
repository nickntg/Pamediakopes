package com.nickntg.pdattractionsdemo;

import android.app.Activity;
import android.os.Bundle;
import android.webkit.WebView;

/**
 * This activity displays web content about
 * a user-selected guide.
 * 
 * @author nick
 *
 */
public class GuideActivity extends Activity {

    @Override
    public void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.guide);
        
    	WebView wv = (WebView) findViewById(R.id.guideview);
    	
    	// Get the guide content and show it.
    	wv.loadDataWithBaseURL(AttractionHelper.getGuideUrl(), 
    			WebServiceHelper.CallGetGuideContent(AttractionHelper.getGuideUrl()), 
    			"text/html", 
    			"UTF-8", 
    			"");
    }
}