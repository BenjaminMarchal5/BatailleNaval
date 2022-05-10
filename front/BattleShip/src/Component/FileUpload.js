import React from 'react';
import { Button } from 'react-bootstrap';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome'
import { faUpload } from '@fortawesome/free-solid-svg-icons'
let FileUploader = ({ onChange }) => {
    const hiddenFileInput = React.useRef(null);

    const handleClick = (e) => {
        hiddenFileInput.current.click();
    };
    const handleChange = (e) => {
        onChange(e);
    };
    return (
        <>
            <Button style={{backgroundColor:'orange',border:'none',maxHeight:'60px'}} onClick={handleClick}><FontAwesomeIcon icon={faUpload} /> Choisir une image</Button>
            <input type="file"
                accept="image/*"
                ref={hiddenFileInput}
                onChange={handleChange}
                style={{ display: 'none' }}
            />
        </>
    );
};
export { FileUploader }