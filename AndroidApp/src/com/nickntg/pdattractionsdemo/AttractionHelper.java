package com.nickntg.pdattractionsdemo;

import java.util.ArrayList;

/**
 * This is a static class that holds information about the
 * currently selected attraction and it's related guides.
 * 
 * Fields are populated with data as the application user
 * navigates from the list of attractions (Athens, Xios, etc)
 * towards a specific attraction, and then requests a specific
 * guide (hotel, beach, telephone, etc).
 * 
 * @author nick
 *
 */
public class AttractionHelper {

	// Attraction url.
	private static String url;
	
	// Attraction description.
	private static String description;
	
	// Attraction guides.
	private static ArrayList<WebFragment> guides;
	
	// Selected attraction guide url.
	private static String guideUrl;
	
	/**
	 * Returns the attraction url.
	 * 
	 * @return
	 *   Url to the attraction.
	 */
	public static String getUrl()
	{
		return AttractionHelper.url;
	}
	
	/**
	 * Sets the attraction url.
	 * 
	 * @param url
	 *   The url to the attraction.
	 */
	public static void setUrl (String url)
	{
		AttractionHelper.url = url;
	}
	
	/**
	 * Returns the attraction description.
	 * 
	 * @return
	 *   String with the attraction description.
	 */
	public static String getDescription()
	{
		return AttractionHelper.description;
	}
	
	/**
	 * Sets the attraction description.
	 * 
	 * @param description
	 *   String with the attraction description.
	 */
	public static void setDescription (String description)
	{
		AttractionHelper.description = description;
	}
	
	/**
	 * Returns the list with the attraction guide fragments.
	 * 
	 * @return
	 *   Array list with fragments of the currently active attraction.
	 */
	public static ArrayList<WebFragment> getGuides()
	{
		return AttractionHelper.guides;
	}
	
	/**
	 * Sets the list with the attraction guide fragments.
	 * 
	 * @param guides
	 *   Array list with fragments of the currently active attraction.
	 */
	public static void setGuides (ArrayList<WebFragment> guides)
	{
		AttractionHelper.guides = guides;
	}
	
	/**
	 * Returns the url of the selected guide.
	 * 
	 * @return
	 *   Url of the selected guide.
	 */
	public static String getGuideUrl()
	{
		return AttractionHelper.guideUrl;
	}
	
	/**
	 * Sets the url of the selected guide.
	 * 
	 * @param guideUrl
	 *   Url to the selected guide.
	 */
	public static void setGuideUrl (String guideUrl)
	{
		AttractionHelper.guideUrl = guideUrl;
	}
	
	/**
	 * Returns the url of the specified guide.
	 * 
	 * @param guide
	 *   Guide to search for (hotel, entertainment, etc).
	 *   
	 * @return
	 *   Url to the specified guide or null if the
	 *   guide was not found.
	 */
	public static String GetGuideUrl (String guide)
	{
		for (int i = 0; i < guides.size(); i++)
		{
			if (guides.get(i).getDescription().equals(guide))
			{
				return guides.get(i).getUrl();
			}
		}
		
		return null;
	}

}
