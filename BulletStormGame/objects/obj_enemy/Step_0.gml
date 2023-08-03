// Define states
enum EnemyState {
    PATROL,
    CHASE,
    SEARCH
}

// Initialize state
if (!variable_instance_exists(id, "state")) {
    state = EnemyState.PATROL;
}

path_to_follow = obj_waypoint_controller.paths[0];

// In the Step Event, move towards the current waypoint
var target_x = path_to_follow[current_waypoint][0];
var target_y = path_to_follow[current_waypoint][1];

// Check if player is within FoV
var direction_to_player = point_direction(x, y, obj_player.x, obj_player.y);
var distance_to_player = point_distance(x, y, obj_player.x, obj_player.y);
var angle_to_player = angle_difference(image_angle, direction_to_player);

switch (state) {
    case EnemyState.PATROL:
        if (angle_to_player <= fov_angle / 2 && distance_to_player <= fov_distance && 
            !collision_line(x, y, obj_player.x, obj_player.y, obj_wall, false, true)) {
            state = EnemyState.CHASE;
			if (move_speed != base_speed)
				move_speed = base_speed;
        }
        break;

    case EnemyState.CHASE:
		// If line of sight is lost, enter SEARCH state.
        if (angle_to_player > fov_angle / 2 || distance_to_player > fov_distance || 
            collision_line(x, y, obj_player.x, obj_player.y, obj_wall, false, true)) {
            state = EnemyState.SEARCH;
        } else {
            target_x = obj_player.x;
            target_y = obj_player.y;

        }
        break;

    case EnemyState.SEARCH:
        if (search_timer < search_time){
			// If line of sight is made, re-enter CHASE state
			if (angle_to_player <= fov_angle / 2 && distance_to_player <= fov_distance && 
            !collision_line(x, y, obj_player.x, obj_player.y, obj_wall, false, true)) {
				state = EnemyState.CHASE;
				search_timer = 0;
			} else {
				target_x = last_known_x;
				target_y = last_known_y;
			}
		}else {
			search_timer = 0;
			state = EnemyState.PATROL;
			move_speed = base_speed;

		}
        break;
}

move_towards_point(target_x, target_y, move_speed);

next_waypoint = (current_waypoint + 1) mod array_length_1d(path_to_follow);

if (state == EnemyState.PATROL) {
    // If reached the waypoint, move to the next one
    if (point_distance(x, y, target_x, target_y) < waypoint_tolerance) {
        if (pause_timer < pause_time) {
            move_speed = 0;
            pause_timer++;
        } else {
            move_speed = base_speed;
            current_waypoint = next_waypoint;
            pause_timer = 0;
        }
    }
}

if (state == EnemyState.CHASE) {
	if (move_speed != base_speed)
		move_speed = base_speed;
	last_known_x = obj_player.x;
	last_known_y = obj_player.y;
}

if (state == EnemyState.SEARCH){
	target_x = last_known_x;
	target_y = last_known_y;
	if (point_distance(x, y, target_x, target_y) < waypoint_tolerance) {
        if (search_timer < search_time) {
            move_speed = 0;
            search_timer++;
        } else {
            move_speed = base_speed;
            current_waypoint = next_waypoint;
            search_timer = 0;
        }
    }
}
// Face direction of movement
if (pause_timer == 0 || state == EnemyState.CHASE) {
    image_angle = point_direction(x, y, target_x, target_y);
}

show_debug_message(state);