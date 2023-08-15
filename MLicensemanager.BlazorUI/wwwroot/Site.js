// site.js
//function toggleCollapses(groupId) {
//    var element = document.getElementById('group-' + groupId);
//    if (element.style.display === 'none') {
//        element.style.display = 'block';
//    } else {
//        element.style.display = 'none';
//    }
//}


function toggleCollapses(groupId) {
    var element = document.getElementById('group-' + groupId);
    var arrowElement = document.getElementById('arrow-' + groupId);

    if (element.style.display === 'none') {
        element.style.display = 'block';
        arrowElement.classList.remove('arrow-down');
        arrowElement.classList.add('arrow-up');
    } else {
        element.style.display = 'none';
        arrowElement.classList.remove('arrow-up');
        arrowElement.classList.add('arrow-down');
    }
}