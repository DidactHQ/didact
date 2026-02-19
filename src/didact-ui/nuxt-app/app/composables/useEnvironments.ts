export const useEnvironments = () => {
  interface Environment {
    id: number;
    name: string;
  }

  const getEnvironments = async (): Promise<Environment[]> => {
    return Promise.resolve([
        { id: 1, name: 'Development' },
        { id: 2, name: 'Production' },
        { id: 3, name: 'Staging' },
    ]);
  }
  
  return {
    getEnvironments
  }
}