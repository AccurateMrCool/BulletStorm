// Define states
enum EnemyState {
    PATROL,
    CHASE,
    SEARCH
}

// Function to check if player is in sight
function canSeePlayer() {
    return abs(angle_difference(image_angle, point_direction(x, y, obj_player.x, obj_player.y))) <= fov_angle / 2
        && point_distance(x, y, obj_player.x, obj_player.y) <= fov_distance
        && !collision_line(x, y, obj_player.x, obj_player.y, obj_wall, false, true);
}

// Initialize state
if (!variable_instance_exists(id, "state")) {
    state = EnemyState.PATROL;
}

path_to_follow = obj_waypoint_controller.paths[0];


switch (state) {
    case EnemyState.PATROL: // Patrolling through waypoints
        if (canSeePlayer()) {
            state = EnemyState.CHASE;
			move_speed = base_speed;
        } else {
			target_x = path_to_follow[current_waypoint][0];
			target_y = path_to_follow[current_waypoint][1];
		}
        break;

    case EnemyState.CHASE: // Player was spotted/Pursuing player

        if (!canSeePlayer()) {
			state = EnemyState.SEARCH;
        } else {
			move_speed = base_speed;
            target_x = obj_player.x;
            target_y = obj_player.y;
            last_known_x = obj_player.x;
            last_known_y = obj_player.y;
			if (point_distance(x,y,obj_player.x,obj_player.y) <= min_distance)
				move_speed = 0;
			else
				move_speed = base_speed;
        }
        break;

    case EnemyState.SEARCH: // Player was spotted, moving to last known position
        if (search_timer < search_time) {
            if (canSeePlayer()) {
                state = EnemyState.CHASE;
                search_timer = 0;
            } else {
                target_x = last_known_x;
                target_y = last_known_y;
            }
        } else {
            search_timer = 0;
            state = EnemyState.PATROL;
            move_speed = base_speed;
        }
        break;
}

move_towards_point(target_x, target_y, move_speed);
next_waypoint = (current_waypoint + 1) mod array_length_1d(path_to_follow);

if (state == EnemyState.PATROL || state == EnemyState.SEARCH) {
    if (point_distance(x, y, target_x, target_y) < waypoint_tolerance) {
        if ((state == EnemyState.PATROL && pause_timer < pause_time) || (state == EnemyState.SEARCH && search_timer < search_time)) {
            move_speed = 0;
            if (state == EnemyState.PATROL) pause_timer++;
            if (state == EnemyState.SEARCH) search_timer++;
        } else {
            move_speed = base_speed;
            current_waypoint = next_waypoint;
            pause_timer = search_timer = 0;
        }
    } else {
		move_speed = base_speed;
	}
}

image_angle = point_direction(x, y, target_x, target_y);
show_debug_message("State " + string(state));
show_debug_message("Target X: " + string(target_x) + " Y: " + string(target_y));
show_debug_message(string(pause_timer) + " " + string(move_speed))



