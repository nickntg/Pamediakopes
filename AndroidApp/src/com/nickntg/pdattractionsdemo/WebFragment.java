package com.nickntg.pdattractionsdemo;

/**
 * This class represents an entity received by the
 * web service. The entity is represented by a url,
 * a description and some html content. Instances
 * of this class are used to receive a list of
 * attractions and a list of guides per attraction.
 * 
 * @author nick
 *
 */
public class WebFragment {
	
	// Entity url.
	private String url;
	
	// Entity description.
	private String description;
	
	// Entity content.
	private String content;
	
	/**
	 * Returns the url of this fragment.
	 * 
	 * @return
	 *   String with url of this fragment.
	 */
	public String getUrl()
	{
		return url;
	}
	
	/**
	 * Sets the url of this fragment.
	 * 
	 * @param url
	 *   String with url of this fragment.
	 */
	public void setUrl (String url)
	{
		this.url = url;
	}
	
	/**
	 * Returns the description of this fragment.
	 * 
	 * @return
	 *   String with the description of this fragment.
	 */
	public String getDescription()
	{
		return description;
	}
	
	/**
	 * Sets the description of this fragment.
	 * 
	 * @param description
	 *   String with the description of this fragment.
	 */
	public void setDescription (String description)
	{
		this.description = description;
	}
	
	/**
	 * Returns the html content of this fragment.
	 * 
	 * @return
	 *   String with the html content of this fragment.
	 */
	public String getContent()
	{
		return content;
	}
	
	/**
	 * Sets the html content of this fragment.
	 * 
	 * @param content
	 *   String with the html content of this fragment.
	 */
	public void setContent (String content)
	{
		this.content = content;
	}
	
	/**
	 * Creates a new instance of this class.
	 * 
	 * @param url
	 *   Fragment url.
	 * @param description
	 *   Fragment description.
	 * @param content
	 *   Fragment html content.
	 */
	public WebFragment (String url, String description, String content)
	{
		this.url = url;
		this.description = description;
		this.content = content;
	}
}
