$(document).ready(() => {
    $('.mark-as-comp').click((event) => {
        var taskId = $(event.target).data('taskid');
        $.ajax({
            type: 'POST',
            url: 'api/tasks/MarkAsComplited?taskId=' + taskId,
            success: function () {
                location.reload();
            }
        });
    });
    $('.mark-as-not-comp').click((event) => {
        var taskId = $(event.target).data('taskid');
        $.ajax({
            type: 'POST',
            url: 'api/tasks/MarkAsNotComplited?taskId=' + taskId,
            success: function () {
                location.reload();
            }
        });
    });
    $('.delete-btn').click((event) => {
        var taskId = $(event.target).data('taskid');
        $.ajax({
            type: 'DELETE',
            url: 'api/tasks/DeleteTask?taskId=' + taskId,
            success: function () {
                location.reload();
            }
        });
    });
    $('.delete-btn').click((event) => {
        var taskId = $(event.target).data('taskid');
        $.ajax({
            type: 'DELETE',
            url: 'api/tasks/DeleteTask?taskId=' + taskId,
            success: function () {
                location.reload();
            }
        });
    });
    //window.location.href = window.location.href.split('?')[0] + "?" + encodeData(filters);
});