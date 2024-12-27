document.getElementById('imageUpload').addEventListener('change', async function (event) {
    const files = event.target.files;
    const imagePreviewContainer = document.getElementById('imagePrevievContainer');
    imagePreviewContainer.innerHTML = '';

    for (const file of files) {
        const formData = new FormData();
        formData.append('image', file);

        const response = await fetch('/Product/UploadImage', {
            method: 'POST',
            body: formData
        });

        const imageUrl = await response.text();

        const imageContainer = document.createElement('div');
        imageContainer.innerHTML = `
        
            <img src="${imageUrl}" alt="Image" width="100" />
            <div class="option-toggle btn-group" role="group">
                <input type="radio" name="MainImageUrl" value="${imageUrl}" class="btn-check"/> Main Image
                <input type="radio" name="SecondaryImageUrl" value="${imageUrl}" class="btn-check"/> Main Image
            </div>
        
        `;
        imagePreviewContainer.appendChild(imageContainer);
    }



});