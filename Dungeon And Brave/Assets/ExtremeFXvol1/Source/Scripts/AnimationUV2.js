var speed:float = 0.5f;
function Start () {

}

function Update () {
	renderer.material.mainTextureOffset.x+=speed * Time.deltaTime;
	if(renderer.material.mainTextureOffset.x>1){
		renderer.material.mainTextureOffset.x = 0;
	}
	if(renderer.material.mainTextureOffset.x<0){
		renderer.material.mainTextureOffset.x = 1;
	}
}