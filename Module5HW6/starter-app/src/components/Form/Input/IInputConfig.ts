export interface InputConfig {
    name: string;
    label: string;
    type: string;
    onChange?: (e: React.ChangeEvent<HTMLInputElement>) => void;
}