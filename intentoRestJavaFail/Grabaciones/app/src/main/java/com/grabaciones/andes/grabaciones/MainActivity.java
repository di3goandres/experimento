package com.grabaciones.andes.grabaciones;

import android.content.DialogInterface;
import android.support.v7.app.ActionBarActivity;
import android.os.Bundle;
import android.view.Menu;
import android.view.MenuItem;
import java.io.File;
import java.io.IOException;
import android.app.Activity;
import android.media.MediaPlayer;
import android.media.MediaPlayer.OnCompletionListener;
import android.media.MediaRecorder;
import android.os.Environment;
import android.view.View;
import android.widget.Button;
import android.widget.TextView;

public class MainActivity extends Activity implements OnCompletionListener {

    TextView txtEstado;
    MediaRecorder grabacion;
    MediaPlayer reproduccion;
    File archivo;
    Button btnGrabar, btnReproducir, btnDetener, btnEnviar;


    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);

        this.txtEstado= (TextView) this.findViewById(R.id.textViewEstado);
        this.btnGrabar= (Button) this.findViewById(R.id.buttonGrabar);
        this.btnDetener= (Button) this.findViewById(R.id.buttonDetener);
        this.btnReproducir= (Button) this.findViewById(R.id.buttonReproducir);
        this.btnEnviar= (Button) this.findViewById(R.id.buttonEnviar);
    }

    @Override
    public boolean onCreateOptionsMenu(Menu menu) {
        // Inflate the menu; this adds items to the action bar if it is present.
        getMenuInflater().inflate(R.menu.menu_main, menu);
        return true;
    }

    @Override
    public boolean onOptionsItemSelected(MenuItem item) {
        // Handle action bar item clicks here. The action bar will
        // automatically handle clicks on the Home/Up button, so long
        // as you specify a parent activity in AndroidManifest.xml.
        int id = item.getItemId();

        //noinspection SimplifiableIfStatement
        if (id == R.id.action_settings) {
            return true;
        }

        return super.onOptionsItemSelected(item);
    }


    @Override
    public void onCompletion(MediaPlayer mp) {
        this.btnGrabar.setEnabled(true);
        this.btnDetener.setEnabled(true);
        this.btnReproducir.setEnabled(true);
        this.txtEstado.setText("Listo");
    }




    public void grabar(View v) {
        this.grabacion = new MediaRecorder();
        this.grabacion.setAudioSource(MediaRecorder.AudioSource.MIC);
        this.grabacion.setOutputFormat(MediaRecorder.OutputFormat.THREE_GPP);
        this.grabacion.setAudioEncoder(MediaRecorder.AudioEncoder.AMR_NB);
        File path = new File(Environment.getExternalStorageDirectory().getPath());
        try {
            archivo = File.createTempFile("temporal", ".mp3", path);
        } catch (IOException e) {
            this.txtEstado.setText("Grabar: exepción 1");
        }
        this.grabacion.setOutputFile(archivo.getAbsolutePath());
        try {
            this.grabacion.prepare();
        } catch (IOException e) {
            this.txtEstado.setText("Grabar: exepción 2");
        }
        this.grabacion.start();
        this.txtEstado.setText("Grabando");
        this.btnGrabar.setEnabled(false);
        this.btnDetener.setEnabled(true);
    }

    public void detener(View v) {
        this.grabacion.stop();
        this.grabacion.release();
        this.reproduccion = new MediaPlayer();
        this.reproduccion.setOnCompletionListener(this);
        try {
            this.reproduccion.setDataSource(archivo.getAbsolutePath());
        } catch (IOException e) {
        }
        try {
            this.reproduccion.prepare();
        } catch (IOException e) {
        }
        this.btnGrabar.setEnabled(true);
        this.btnDetener.setEnabled(false);
        this.btnReproducir.setEnabled(true);
        this.txtEstado.setText("Listo para reproducir");
    }

    public void reproducir(View v) {
        this.reproduccion.start();
        this.btnGrabar.setEnabled(false);
        this.btnDetener.setEnabled(false);
        this.btnReproducir.setEnabled(false);
        this.txtEstado.setText("Reproduciendo");
    }

    public void enviar(View v){
        this.txtEstado.setText("Reproduciendo");
    }



}
