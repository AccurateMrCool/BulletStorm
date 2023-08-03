
// Draw waypoints as small circles and lines connecting them
for (var i = 0; i < array_length_1d(paths[0]) - 1; i++) {
    var x1 = path1[i][0];
    var y1 = path1[i][1];
    var x2 = path1[i + 1][0];
    var y2 = path1[i + 1][1];
    
    // Draw a line from one waypoint to the next
    draw_line(x1, y1, x2, y2);
    
    // Draw a small circle at each waypoint
    draw_circle(x1, y1, 5, false);
}

// Draw a circle at the last waypoint if it exists
if (array_length_1d(paths[0]) > 0) {
    var last_x = path1[array_length_1d(paths[0]) - 1][0];
    var last_y = path1[array_length_1d(paths[0]) - 1][1];
    draw_circle(last_x, last_y, 5, false);
	draw_line(last_x, last_y, path1[0,0],path1[0,1] );
}