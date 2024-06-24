import React, { FC, ReactElement } from "react";
import Form from "../../Form";
import {InputConfig} from "../../Form/Input/IInputConfig";

interface UserFormProps {
    title: string,
    inputs: InputConfig[],
    buttonText: string,
    handleSubmit: (event: React.FormEvent<HTMLFormElement>) => void;
}

const UserForm: FC<UserFormProps> = (props: UserFormProps): ReactElement => {

    const { title, inputs, buttonText, handleSubmit } = props;

    return (
       <Form title={title} inputs={inputs} buttonText={buttonText} handleSubmit={handleSubmit} />
    );
};

export default UserForm;
