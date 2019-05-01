var particleSpanwner:GameObject[];
var indexSpawn:int = 0;
var epictime:boolean;
private var timetemp = 0;
private var count = 0;
function Start(){
	timetemp = Time.time;
}
function Update () {
	this.transform.RotateAround(Vector3.up,Time.deltaTime * 0.2f);

	if(Input.GetButtonDown("Fire1"))
	{
    	var ray = GameObject.Find("Main Camera").camera.ScreenPointToRay (Input.mousePosition);
   		var hit : RaycastHit;
   		
    	if (Physics.Raycast (ray, hit, 100)) {
    	if(hit.transform.tag == "ground"){
       		if(particleSpanwner.Length>0){
       			SpawnParticle(hit.point);
            }
   		}
   		}

	}
	if(epictime){
		if(Time.time>timetemp+0.7){
			timetemp = Time.time;
			SpawnParticle(new Vector3(Random.Range(-10,10),0,Random.Range(-10,10)));
			indexSpawn = Random.Range(0,particleSpanwner.Length);
		}
	}
}


function SpawnParticle(position:Vector3){
	var offset:Vector3 = Vector3.zero;
	
	if(particleSpanwner[indexSpawn].GetComponent(ParticleSetting)){
       offset = particleSpanwner[indexSpawn].GetComponent(ParticleSetting).PositionOffset;
    }
    var particle:GameObject = GameObject.Instantiate(particleSpanwner[indexSpawn], position + offset, Quaternion.identity);   	
}





function OnGUI(){
	if(GUI.Button(new Rect(10,10,150,30),"Prev")){
		indexSpawn--;
		if(indexSpawn<0){
			indexSpawn = particleSpanwner.Length-1;
		}
	}
	GUI.Label(new Rect(10,40,1000,30),"Particle Name: "+particleSpanwner[indexSpawn].name.ToString());
	if(GUI.Button(new Rect(170,10,150,30),"Next")){
		indexSpawn++;
		if(indexSpawn>=particleSpanwner.Length){
			indexSpawn = 0;
		}
	}
	
	if(GUI.Button(new Rect(350,10,120,30),"Ground "+GameObject.Find("Plane").gameObject.renderer.enabled)){
		if(GameObject.Find("Plane").gameObject.renderer.enabled){
			GameObject.Find("Plane").gameObject.renderer.enabled = false;
		}else{
			GameObject.Find("Plane").gameObject.renderer.enabled = true;
		}
	}
	
	if(GUI.Button(new Rect(480,10,120,30),"Show time")){
		if(epictime){
			epictime = false;
		}else{
			epictime = true;
		}
	}
	
	
}