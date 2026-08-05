import type { SidebarNavItem } from '~/types/Sidebar';

export const useSidebarData = () => {
    const items: SidebarNavItem[] = [
        {
            title: 'Dashboard',
            path: '/',
            iconFilename: 'dashboard-icon.png'
        },
        {
            title: 'Flows',
            path: '/flows',
            iconFilename: 'flows-icon.png'
        },
        {
            title: 'Flowruns',
            path: '/flowruns',
            iconFilename: 'flow-runs-icon.png'
        },
        {
            title: 'Deployments',
            path: '/deployments',
            iconFilename: 'deployments-icon.png'
        },
        {
            title: 'Queues',
            path: '/queues',
            iconFilename: 'queues-icon.png'
        },
        {
            title: 'Engines',
            path: '/engines',
            iconFilename: 'engines-icon.png'
        },
        {
            title: 'Variables',
            path: '/variables',
            iconFilename: 'variables-icon.png'
        },
        {
            title: 'Secrets',
            path: '/secrets',
            iconFilename: 'secrets-icon.png'
        },
        {
            title: 'Alerts',
            path: '/alerts',
            iconFilename: 'alerts-icon.png'
        }
    ];

    return {
        items
    }
}