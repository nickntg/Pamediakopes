package com.nickntg.pdattractionsdemo;

import java.util.ArrayList;

import android.app.ListActivity;
import android.content.Intent;
import android.os.Bundle;
import android.view.View;
import android.widget.ArrayAdapter;
import android.widget.ListAdapter;
import android.widget.ListView;

/**
 * This activity allows the user to select a specific attraction
 * from a list of attractions.
 * 
 * @author nick
 *
 */
public class AttractionsActivity extends ListActivity {

	// Fragment with attractions.
	ArrayList<WebFragment> list;
	
	@Override
	public void onCreate(Bundle savedInstanceState) {
	  super.onCreate(savedInstanceState);
	  
	  // Get the attractions.
	  list = WebServiceHelper.CallGetLocations();
	  
	  // Populate the list view with the attraction descriptions.
	  String[] attractions = new String[list.size()];
	  for (int i = 0; i < list.size(); i++)
	  {
		  attractions[i] = list.get(i).getDescription();
	  }

	  setListAdapter((ListAdapter) new ArrayAdapter<String>(this, R.layout.listitem, attractions));

	  ListView lv = getListView();
	  lv.setTextFilterEnabled(true);
	}

	// Launches the attraction detailed activity, once
	// the user selects a specific attraction.
	@Override
	protected void onListItemClick(ListView l, View v, int position, long id) {
		super.onListItemClick(l, v, position, id);
		
		AttractionHelper.setUrl(list.get(position).getUrl());;
		AttractionHelper.setGuides(WebServiceHelper.CallGetGuides(AttractionHelper.getUrl()));;
		AttractionHelper.setDescription(WebServiceHelper.CallGetAttractionDescription(AttractionHelper.getUrl()));;
		
		startActivity(new Intent (this, AttractionActivity.class));
	}
	
}
