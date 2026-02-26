export const useEnvironments = () => {

  const selectedEnvironment = ref<Environment>({ id: 1, name: 'Development' });

  const getEnvironments = async (): Promise<Environment[]> => {
    return Promise.resolve([
        { id: 1, name: 'Development' },
        { id: 2, name: 'Production' },
        { id: 3, name: 'Staging' },
    ]);
  }
  
  return {
    selectedEnvironment,
    getEnvironments
  }
}