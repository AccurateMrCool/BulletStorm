
// Move enemy
var nextX = x + move_speed * move_direction;

// Check if hitting a wall
if (!collision_line(x, y, nextX, y, obj_wall, false, true)) {
    // If not hitting a wall, move enemy
    x += move_speed * move_direction;
} else {
    // If a wall is hit, reverse direction and move a bit back
    move_direction *= -1;
    x += 5 * move_direction; // Adjust the number as needed to create enough space between the enemy and the wall
}

show_debug_message(move_direction)