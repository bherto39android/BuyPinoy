package bherto39android.com.buypinoy.bherto39android.com.buypinoy.common.tasks;

import android.os.AsyncTask;

import org.springframework.http.converter.StringHttpMessageConverter;
import org.springframework.web.client.RestTemplate;

/**
 * Created by 00302 on 2/5/2015.
 */
public class RetrieveJsonTask extends AsyncTask<Void,Void,Void> {


    @Override
    protected Void doInBackground(Void... params) {
        //do nothing
        // The connection URL
        String url="https://ajax.googleapis.com/ajax/" +
                "services/search/web?v=1.0&q={query}";

            // Create a new RestTemplate instance
            RestTemplate restTemplate = new RestTemplate();

            // Add the String message converter
            restTemplate.getMessageConverters().add(new StringHttpMessageConverter());
            try {
                // Make the HTTP GET request, marshaling the response to a String
                String result = restTemplate.getForObject(url, String.class, "Android");
                System.out.println(result);
            } catch (Exception ex) {
                System.out.println(ex.getMessage());
                return null;
            }

        return null;
    }
}
