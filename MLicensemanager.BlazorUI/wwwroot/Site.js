

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

//Sweet Aler
function confirmSaveChanges() {
    return Swal.fire({
        title: 'Are you sure?',
        text: "You won't be able to revert this!",
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'Yes, save it!'
    }).then((result) => {
        return result.isConfirmed;
    });
}
// custom.js

window.addProductToCustomerTable = function (productId) {
    var productRow = document.querySelector(`#allProductsTable [data-product-id="${productId}"]`);

    if (productRow) {
        var newRow = productRow.cloneNode(true);
        newRow.querySelector('button').innerText = 'Remove';
        newRow.querySelector('button').addEventListener('click', function () {
            newRow.remove();
        });

        document.querySelector('#customerProductsTable tbody').appendChild(newRow);
    }
};
// Add Selected row to Customer Row

window.addProductToCustomerTable = function (productId) {
    // Find the Add button of the product with the given productId
    var addButton = document.querySelector(`#allProductsTable [data-product-id="${productId}"] button`);

    if (addButton) {
        // Find the parent row of the product in the table
        var productRow = addButton.closest('tr');

        // Clone the entire row
        var newRow = productRow.cloneNode(true);

        // Find the Remove button in the cloned row
        var removeButton = newRow.querySelector('button');

        // Set the HTML content of the Remove button to an icon (Font Awesome trash icon)
        removeButton.innerHTML = '<i class="fas fa-trash"></i>';

        // Add a click event listener to the Remove button
        removeButton.addEventListener('click', function () {
            // Remove the entire row when the Remove button is clicked
            newRow.remove();

            // Enable the corresponding Add button in the original table
            addButton.disabled = false;

            // To do: Enable the original row when the Remove button is clicked
            productRow.classList.remove('disabled');
        });

        // Disable the Add button to prevent adding the same product again
        addButton.disabled = true;

        // To do: Disable the entire original row (not just the cloned row) when the Add button is clicked
        productRow.classList.add('disabled');

        // Append the cloned row to the customer products table
        document.querySelector('#customerProductsTable tbody').appendChild(newRow);
    };


    // In a .js or .ts file (e.g., CustomFunctions.js)
    
}

function toggleGroupDetails(groupId) {
    var groupDetailsDiv = document.getElementById(`group-details-${groupId}`);
    if (groupDetailsDiv) {
        if (groupDetailsDiv.style.display === "none") {
            groupDetailsDiv.style.display = "block";
        } else {
            groupDetailsDiv.style.display = "none";
        }
    }
};
// In a JavaScript file (e.g., custom.js)
function showConfirmationDialog() {
    return Swal.fire({
        title: 'Confirmation',
        text: 'Are you sure you want to change the group name?',
        icon: 'warning',
        showCancelButton: true,
        confirmButtonText: 'Yes',
        cancelButtonText: 'Cancel'
    }).then((result) => {
        return result.isConfirmed;
    });
}