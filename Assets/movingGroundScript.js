#pragma strict

function Start () {

}

function Update () {

}

function OnTriggerEnter2D(other: Collider2D) {
	other.transform.parent = this.transform.parent;
}

function OnTriggerExit2D(other: Collider2D) {
	other.transform.parent = null;
}