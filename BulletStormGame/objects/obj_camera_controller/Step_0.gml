// Define the view (camera) size
var view_width = 1366;
var view_height = 768;

// Determine the target position for the camera
var target_x = obj_player.x - view_width / 2;
var target_y = obj_player.y - view_height / 2;

// Clamp the camera position to the room boundaries
target_x = clamp(target_x, 0, room_width - view_width);
target_y = clamp(target_y, 0, room_height - view_height);

// Get the current camera position
var current_x = camera_get_view_x(cam);
var current_y = camera_get_view_y(cam);

// Define the damping factor (between 0 and 1, higher value means faster movement)
var damping = 0.05;

// Calculate the new camera position using linear interpolation (lerp) with the damping factor
var new_x = lerp(current_x, target_x, damping);
var new_y = lerp(current_y, target_y, damping);

// Update the camera (view) position
camera_set_view_pos(cam, new_x, new_y);