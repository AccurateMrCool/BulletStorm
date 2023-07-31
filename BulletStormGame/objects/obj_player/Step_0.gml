// If player is bouncing, move them in the bounce direction
if (bounce_speed > 0) {
    x += lengthdir_x(bounce_speed, bounce_direction);
    y += lengthdir_y(bounce_speed, bounce_direction);
    bounce_speed -= deceleration; // decrease the bounce speed over time
    if (bounce_speed < 0) bounce_speed = 0; // stop the player from bouncing in the opposite direction
} else {
    // Reset movement each step
    moveX = 0;
    moveY = 0;

    // Check for player input
    if (keyboard_check(ord("W"))) moveY -= move_speed;
    if (keyboard_check(ord("S"))) moveY += move_speed;
    if (keyboard_check(ord("A"))) moveX -= move_speed;
    if (keyboard_check(ord("D"))) moveX += move_speed;

    // Apply the movement
    x += moveX;
    y += moveY;
}