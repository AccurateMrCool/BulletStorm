// Check collision with player
if (place_meeting(x, y, obj_player)) {
    var player = instance_place(x, y, obj_player);
    player.bounce_speed = enemy_bounce_speed;
    player.bounce_direction = point_direction(x, y, player.x, player.y);
}