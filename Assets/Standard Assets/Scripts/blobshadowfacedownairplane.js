//Hier stellen wir den Blobshadow auf die immer richtige Rotation ein. Durch das anh�ngen an den Cube wird zwar die Position des Schattens immer auf Position des W�rfels gehalten. Leider wird auch dessen Rotation �bertragen. Am Boden und auf der Ebene spielt das noch keine grosse Rolle. Bei Schr�gen schon. Und in der Luft sowieso. 90 Grad deswegen weil der Schatten bei 0 Grad nach vorn zeigt. 
function Update () {
transform.eulerAngles = Vector3(90,moveairplane.airplaneangley, 0);
}