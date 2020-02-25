using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

	[Header("Variáveis para controle de Câmera")]
	public 	Transform 	PlayerTransform;
	private Camera 		cam;
    public 	Transform 	limiteCamEsc,limiteCamDir,limiteCamSup,limiteCamInf;
    public  float 		speedCam;

    void Start()
    {
        cam = Camera.main;
    }

    void LateUpdate() //Atualiza depois de todos os updates do jogo no mesmo frame
    {

    	float posCamX = PlayerTransform.position.x;
    	float posCamY = PlayerTransform.position.y;

    	if(cam.transform.position.x < limiteCamEsc.position.x && PlayerTransform.position.x < limiteCamEsc.position.x){
    		posCamX = limiteCamEsc.position.x;
    	}else if(cam.transform.position.x > limiteCamDir.position.x && PlayerTransform.position.x > limiteCamDir.position.x){
    		posCamX = limiteCamDir.position.x;
    	}

    	if(cam.transform.position.y < limiteCamInf.position.y && PlayerTransform.position.y < limiteCamInf.position.y){
    		posCamY = limiteCamInf.position.y;
    	}else if(cam.transform.position.y > limiteCamSup.position.y && PlayerTransform.position.y > limiteCamSup.position.y){
    		posCamY = limiteCamSup.position.y;
    	}

    	Vector3 posCam = new Vector3(posCamX,posCamY, cam.transform.position.z);

    	cam.transform.position = Vector3.Lerp(cam.transform.position, posCam, speedCam * Time.deltaTime);
    }
}
