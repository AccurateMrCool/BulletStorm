draw_self();
var left_fov_angle = image_angle - fov_angle / 2;
var right_fov_angle = image_angle + fov_angle / 2;

var left_fov_x = x + lengthdir_x(fov_distance, left_fov_angle);
var left_fov_y = y + lengthdir_y(fov_distance, left_fov_angle);
var right_fov_x = x + lengthdir_x(fov_distance, right_fov_angle);
var right_fov_y = y + lengthdir_y(fov_distance, right_fov_angle);

draw_line(x, y, left_fov_x, left_fov_y);
draw_line(x, y, right_fov_x, right_fov_y);

// Optional: Draw a circle representing the edge of the FOV
draw_set_alpha(.1)
draw_circle(x, y, fov_distance, false);
draw_set_alpha(1)