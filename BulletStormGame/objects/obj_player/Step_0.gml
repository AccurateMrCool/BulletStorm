// Reset movement each step
var moveX = 0;
var moveY = 0;

// Check for player input
if (keyboard_check(ord("W"))) moveY -= move_speed;
if (keyboard_check(ord("S"))) moveY += move_speed;
if (keyboard_check(ord("A"))) moveX -= move_speed;
if (keyboard_check(ord("D"))) moveX += move_speed;

// Check for wall at new X position
if (!place_meeting(x + moveX, y, obj_wall)) {
    // If no wall, apply the horizontal movement
    x += moveX;
}

// Check for wall at new Y position
if (!place_meeting(x, y + moveY, obj_wall)) {
    // If no wall, apply the vertical movement
    y += moveY;
}

if (mouse_check_button_pressed(mb_left)){
	bullet = instance_create_layer(x,y,"Projectiles", obj_bullet);	
	bullet.direction = image_angle;
	bullet.image_angle = bullet.direction;
	bullet.speed = 10;
}

image_angle = point_direction(x, y, mouse_x, mouse_y);