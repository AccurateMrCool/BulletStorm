
// On collision with enemy, bounce in opposite direction
direction = point_direction(x, y, obj_enemy.x, obj_enemy.y) + 180;
speed = bounce_speed; // where bounce_speed is a new variable you'll define in the create event (e.g., bounce_speed = 2;)