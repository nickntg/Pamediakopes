package com.nickntg.pdattractionsdemo;

import java.util.ArrayList;

import org.ksoap2.SoapEnvelope;
import org.ksoap2.serialization.SoapObject;
import org.ksoap2.serialization.SoapPrimitive;
import org.ksoap2.serialization.SoapSerializationEnvelope;
import org.ksoap2.transport.HttpTransportSE;

/**
 * This class provides methods that communicate
 * with the web service to receive data.
 * 
 * @author nick
 *
 */
public class WebServiceHelper {
	
	// Base url of web services.
	private static final String BASE_URL = "http://192.168.1.99/PDWebFetchService/";
	
	// Base namespace.
	private static final String BASE_NAMESPACE = "http://pamediakopes.gr/";
	
	// Description of the GetLocations web method.
	private static final String SOAP_ACTION_LOCATIONS = BASE_NAMESPACE + "GetLocations";
	private static final String METHOD_NAME_LOCATIONS = "GetLocations";
	private static final String NAMESPACE_LOCATIONS = BASE_NAMESPACE;
	private static final String LOCATIONS_URL = BASE_URL + "LocationService.asmx";
	
	// Description of the GetGuides web method.
	private static final String SOAP_ACTION_GUIDES = BASE_NAMESPACE + "GetGuides";
	private static final String METHOD_NAME_GUIDES = "GetGuides";
	private static final String NAMESPACE_GUIDES = BASE_NAMESPACE;
	private static final String GUIDES_URL = BASE_URL + "LocationService.asmx";
	
	// Description of the GetAttracthDescription web method. 
	private static final String SOAP_ACTION_ATTRACTIONINFO = BASE_NAMESPACE + "GetAttractionDescription";
	private static final String METHOD_NAME_ATTRACTIONINFO = "GetAttractionDescription";
	private static final String NAMESPACE_ATTRACTIONINFO = BASE_NAMESPACE;
	private static final String ATTRACTIONINFO_URL = BASE_URL + "LocationService.asmx";
	
	// Description of the GetGuideContent web method.
	private static final String SOAP_ACTION_GUIDECONTENT = BASE_NAMESPACE + "GetGuideContent";
	private static final String METHOD_NAME_GUIDECONTENT = "GetGuideContent";
	private static final String NAMESPACE_GUIDECONTENT = BASE_NAMESPACE;
	private static final String GUIDECONTENT_URL = BASE_URL + "LocationService.asmx";
	
	// Connect/receive timeout in mills.
	private static final int TIMEOUT = 10000;

	/**
	 * Returns a list of attractions received by the web service.
	 * 
	 * @return
	 *   ArrayList with attractions received by the web service.
	 */
	public static ArrayList<WebFragment> CallGetLocations ()
	{
		return CallFragmentService(NAMESPACE_LOCATIONS, 
				METHOD_NAME_LOCATIONS, 
				LOCATIONS_URL, 
				SOAP_ACTION_LOCATIONS,
				null,
				null);
	}
	
	/**
	 * Returns a list of guides for an attraction.
	 * 
	 * @param url
	 *   Url of the attraction to look for.
	 * @return
	 *   ArrayList with guides for the attraction.
	 */
	public static ArrayList<WebFragment> CallGetGuides (String url)
	{
		return CallFragmentService(NAMESPACE_GUIDES, 
				METHOD_NAME_GUIDES, 
				GUIDES_URL, 
				SOAP_ACTION_GUIDES,
				"url",
				url);		
	}
	
	/**
	 * Returns a string with the description of an attraction.
	 * 
	 * @param url
	 *   Url of the attraction to look for.
	 * @return
	 *   String with the attraction description.
	 */
	public static String CallGetAttractionDescription (String url)
	{
		return CallStringService(NAMESPACE_GUIDECONTENT, 
				METHOD_NAME_ATTRACTIONINFO, 
				ATTRACTIONINFO_URL, 
				SOAP_ACTION_ATTRACTIONINFO, 
				"url",
				url);
	}
	
	/**
	 * Returns a string with a guide's content.
	 * 
	 * @param url
	 *   Url of the guide to look for.
	 * @return
	 *   String with html guide content.
	 */
	public static String CallGetGuideContent (String url)
	{
		return CallStringService(NAMESPACE_ATTRACTIONINFO, 
				METHOD_NAME_GUIDECONTENT, 
				GUIDECONTENT_URL, 
				SOAP_ACTION_GUIDECONTENT, 
				"url",
				url);
	}
	
	// Calls a web service that returns a string
	// and accepts a single parameter.
	public static String CallStringService (String namespace,
			String method,
			String url,
			String soap,
			String propertyName,
			String propertyValue)
	{
		try
		{
			SoapObject request = new SoapObject(namespace, method);
			request.addProperty(propertyName, propertyValue);
			
			SoapSerializationEnvelope envelope = new SoapSerializationEnvelope(SoapEnvelope.VER11);
			envelope.dotNet = true;
			envelope.setOutputSoapObject(request);
			
			HttpTransportSE transport = new HttpTransportSE(url, TIMEOUT);
			
			transport.call(soap, envelope);
			
			SoapObject rsp = (SoapObject)envelope.bodyIn;
			
			SoapPrimitive r = (SoapPrimitive)rsp.getProperty(0);
			return r.toString();
			
		}
		catch (Exception ex)
		{
			return null;
		}
	}
	
	// Calls a web service that returns a list of WebFragment instances
	// and optionally accepts a parameter.
	private static ArrayList<WebFragment> CallFragmentService (String namespace, 
			String method, 
			String url, 
			String soap,
			String propertyName,
			String propertyValue)
	{
		try
		{
			SoapObject request = new SoapObject(namespace, method);
			
			// Only set the parameter if there is a property 
			// name specified by the caller.
			if (propertyName != null)
			{
				request.addProperty(propertyName, propertyValue);
			}
			
			SoapSerializationEnvelope envelope = new SoapSerializationEnvelope(SoapEnvelope.VER11);
			envelope.dotNet = true;
			envelope.setOutputSoapObject(request);
			
			HttpTransportSE transport = new HttpTransportSE(url, TIMEOUT);
			
			transport.call(soap, envelope);
			
			SoapObject rsp = (SoapObject)envelope.bodyIn;
			
			SoapObject r = (SoapObject)rsp.getProperty(0);
			
			ArrayList<WebFragment> frags = new ArrayList<WebFragment>();
			
			for (int i = 0; i < r.getPropertyCount(); i++)
			{
				SoapObject child = (SoapObject)r.getProperty(i);
				frags.add(new WebFragment(child.getPropertyAsString(0),
						child.getPropertyAsString(1),
						child.getPropertyAsString(2)));
			}
			
			return frags;
			
		}
		catch (Exception ex)
		{
			return null;
		}
	}
}
