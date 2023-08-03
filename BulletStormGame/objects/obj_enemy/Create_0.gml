//Define speed and direction
base_speed = 3;
move_speed = base_speed;

waypoint_tolerance = 5;

current_waypoint = 0;

pause_time = 120;
pause_timer = 0;

//FoV

fov_angle = 60; // Angle of vision
fov_distance = 400; // Maximum distance to spot player
player_spotted = false;

search_time = 200;
search_timer = 0;

last_known_x = x;
last_known_y = y;