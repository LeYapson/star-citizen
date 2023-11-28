extends DirectionalLight3D


func _on_Timer_timeout():
	#on timer timeout look at the player location
	if Globals.player != null:
		look_at(Globals.player.global_transfomr.origin, Vector3.UP)
