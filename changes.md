* Reworked the whole projectile system
* Blue bullet slime doesn't shoot after death anymore
* Dino is a bit more angry now
* Halo buffed

* Projectile light/poof effects wont work after there are 99 projectiles in game
* Mob projectiles are capped at 199
* Removed Tags.Torch => Tags.MobProjectile
* Removed Tags.Gramaphone => Tags.PlayerProjectile 
* Projectiles wont be able to hit mobs/paintings/tnt in rooms that there are no players in
* All projectiles will die after some time now
* The game will give up trying to process past time if it is more than 0.25 of a second
* If player has more than 69 projectiles old projectiles will start to break
* Improved missile
* Added bounce cap of 8