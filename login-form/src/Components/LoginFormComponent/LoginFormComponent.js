import React from "react"
import Form from 'react-bootstrap/Form'
import Button from 'react-bootstrap/Button'
import './LoginFormComponent.css'


function LoginFormComponent() {
    return (
        <div className="loginContainer">
            <Form>
                <Form.Group controlId="formEmail">
                    <Form.Label>Email address</Form.Label>
                    <Form.Control type="email" placeholder="Enter email" />
               </Form.Group>
                <Form.Group controlId="formPassword">
                    <Form.Label>Password</Form.Label>
                    <Form.Control type="password" placeholder="Password" />
                </Form.Group>
                <Button variant="primary" type="submit">
                    Submit
                </Button>
            </Form>
        </div>
    );
}

export default LoginFormComponent;
