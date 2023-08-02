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